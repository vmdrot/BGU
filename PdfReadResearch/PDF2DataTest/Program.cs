using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iTextSharp.text.pdf.parser;
using Newtonsoft.Json;
using Pdf2DataLib;
using Pdf2DataLib.Spares;
using PDF2DataTest.Spares;

namespace PDF2DataTest
{
    class Program
    {
        #region field(s)
        private static Dictionary<string, CmdHandler> _cmdHandlers;
        private static List<string> _noLogArgsHandlers = new List<string> { nameof(ExtractTableRectangles).ToLower(), nameof(ExtractTableStatsBulk).ToLower(), nameof(GetSuspectedRowBreaksFromTableStats).ToLower(), nameof(BuildCellsMatrix).ToLower()};
        #endregion

        #region inner type(s)
        private delegate int CmdHandler(string[] args);
        #endregion

        #region Init CMD handlers
        private static Dictionary<string, CmdHandler> AutoDetectCMDHandlers()
        {
            Dictionary<string, CmdHandler> rslt = new Dictionary<string, CmdHandler>();
            Type thisType = typeof(Program);
            MethodInfo[] methods = thisType.GetMethods();
            foreach (MethodInfo mi in methods)
            {
                //skip the Main, otherwise we'll end up in an endless recursion
                if (mi.Name == nameof(Main))
                    continue;
                if (mi.ReturnType != typeof(int))
                    continue;
                ParameterInfo[] args = mi.GetParameters();
                if (args == null || args.Length != 1)
                    continue;
                //if (args[0].GetType() != typeof(string[])) //this doesn't work
                //    continue;
                if (args[0].ToString() != "System.String[] args") //the only cheapest way to get this done
                    continue;
                rslt.Add(mi.Name.ToLower(), (CmdHandler)mi.CreateDelegate(typeof(CmdHandler)));
            }
            return rslt;
        }
        private static void FillCmdHandlers()
        {
            #region auto-detect
            _cmdHandlers = AutoDetectCMDHandlers();
            #endregion

            #region fill necessary CMD aliases (if any)
            _cmdHandlers.Add(string.Empty, ResearchTableEvents);
            #endregion
        }
        #endregion

        #region the sacred Main()
        public static int Main(string[] args)
        {
            FillCmdHandlers();
            string keyArg = args.Length > 0 ? args[0].ToLower() : null;
            if (!string.IsNullOrWhiteSpace(keyArg) && _cmdHandlers.ContainsKey(keyArg))
            {
                List<string> origArgs = new List<string>(args);
                origArgs.RemoveAt(0);
                if (!_noLogArgsHandlers.Contains(keyArg))
                    LogCmdArgs(_cmdHandlers[keyArg].Method.Name, origArgs.ToArray());
                try { return _cmdHandlers[keyArg](origArgs.ToArray()); } catch (Exception ex) { Console.WriteLine(ex); return 1; }
            }
            else
                return _cmdHandlers[string.Empty](args);
        }
        #endregion

        #region usage & help
        public static int ShowUsage(string[] args)
        {
            Console.WriteLine("A valid command key must be supplied. See below the list of available commands:");
            foreach (string key in _cmdHandlers.Keys)
                Console.WriteLine("  {0}", key);
            return 1;
        }
        #endregion

        #region applied CMD handlers
        public static int ResearchTableEvents(string[] args)
        {
            Dictionary<int, List<RectangleInfo>> rects = new Dictionary<int, List<RectangleInfo>>();

            using (iText.Kernel.Pdf.PdfReader reader = new iText.Kernel.Pdf.PdfReader(args[0]))
            {
                using (PdfDocument doc = new PdfDocument(reader))
                {
                    PdfDocumentContentParser parser = new PdfDocumentContentParser(doc);
                    int pgsCount = doc.GetNumberOfPages();
                    for (int pg = 1; pg <= pgsCount; pg++)
                    {
                        TablesEventListener listener = new TablesEventListener();
                        parser.ProcessContent(pg, listener);
                        List<string> texts = listener.GetTexts();
                        List<PathInfo> pathInfos = listener.GetClippingPaths();
                        Console.WriteLine("listener.GetTexts({1}) = {0}", JsonConvert.SerializeObject(texts, Formatting.None), texts.Count);
                        Console.WriteLine("listener.pathInfos({1}) = {0}", JsonConvert.SerializeObject(pathInfos, Formatting.None), pathInfos.Count);
                        rects.Add(pg, PdfTableHelper.ClippingPaths2RectangleInfosDistinct(pathInfos));
                    }

                    Console.WriteLine("RectangleInfosDistinct({1}) = {0}", JsonConvert.SerializeObject(rects, Formatting.None), rects.Count);
                }
            }
            return 0;
        }

        public static int ExtractTableRectangles(string[] args)
        {
            //Console.Read();
            Dictionary<int, List<RectangleInfo>> rects = new Dictionary<int, List<RectangleInfo>>();
            string pdfPath = args[0];
            bool trimOverlaps = args.Length > 1 && !string.IsNullOrWhiteSpace(args[1]) ? bool.Parse(args[1]) : false;
            bool chatty = args.Length > 2 && !string.IsNullOrWhiteSpace(args[2]) ? bool.Parse(args[2]) : false;
            using (iText.Kernel.Pdf.PdfReader reader = new iText.Kernel.Pdf.PdfReader(pdfPath))
            {
                using (PdfDocument doc = new PdfDocument(reader))
                {
                    PdfDocumentContentParser parser = new PdfDocumentContentParser(doc);
                    int pgsCount = doc.GetNumberOfPages();
                    for (int pg = 1; pg <= pgsCount; pg++)
                    {
                        TablesEventListener listener = new TablesEventListener();
                        listener.Chatty = chatty;
                        parser.ProcessContent(pg, listener);
                        List<PathInfo> pathInfos = listener.GetClippingPaths();
                        List<RectangleInfo> currRaw = PdfTableHelper.ClippingPaths2RectangleInfosDistinct(pathInfos);
                        rects.Add(pg, trimOverlaps ? PdfTableHelper.RemoveOverlaps(currRaw) : currRaw);
                    }

                    Console.WriteLine("{0}", JsonConvert.SerializeObject(rects, Formatting.None));
                }
            }
            return 0;
        }

        public static int ExtractTextByRects(string[] args)
        {
            string pdfPath = args[0];
            string rectsPath = args[1];
            string outputPath = args.Length > 2 && !string.IsNullOrWhiteSpace(args[2]) ? args[2] : null;
            var rects = ExtractTextByRectsWorker(pdfPath, rectsPath);
            if (string.IsNullOrWhiteSpace(outputPath)) Console.WriteLine("{0}", JsonConvert.SerializeObject(rects, Formatting.None));
            else File.WriteAllText(outputPath, JsonConvert.SerializeObject(rects, Formatting.None), Encoding.UTF8);
            return 0;
        }

        private static Dictionary<int, List<RectangleInfoEx>> ExtractTextByRectsWorker(string pdfPath, string rectsPath)
        {
            Dictionary<int, List<RectangleInfoEx>> rects = JsonConvert.DeserializeObject<Dictionary<int, List<RectangleInfoEx>>>(File.ReadAllText(rectsPath), new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            using (iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(pdfPath))
            {
                foreach (int pg in rects.Keys)
                {
                    for (int i = 0; i < rects[pg].Count; i++)
                    {
                        var rxi = rects[pg][i];
                        iTextSharp.text.Rectangle rect = new iTextSharp.text.Rectangle(rxi.ulx, rxi.uly, rxi.brx, rxi.bry);
                        RenderFilter regionFilter = new RegionTextRenderFilter(rect);
                        //FontRenderFilter fontFilter = new FontRenderFilter();
                        ITextExtractionStrategy strategy = new FilteredTextRenderListener(
                                new LocationTextExtractionStrategy(), regionFilter);
                        rects[pg][i].Text = iTextSharp.text.pdf.parser.PdfTextExtractor.GetTextFromPage(reader, pg, strategy);
                    }
                }
            }
            return rects;
        }

        private static Dictionary<int,List<List<string>>> ExtractTextsFromRectsWorker(Dictionary<int, List<RectangleInfoEx>> src)
        {
            Dictionary<int, List<List<string>>> rslt = new Dictionary<int, List<List<string>>>();
            
            foreach (int pg in src.Keys)
            {
                List<float> topYs = new List<float>(src[pg].Select(r => r.uly).Distinct().OrderByDescending( f => f));
                List<List<string>> texts = new List<List<string>>();
                foreach (float currTopY in topYs)
                {
                    List<string> currRow = new List<string>();
                    List<RectangleInfoEx> currRects = new List<RectangleInfoEx>(src[pg].Where(r => r.uly == currTopY).OrderBy(r => r.ulx));
                    foreach (var rect in currRects)
                    {
                        currRow.Add(rect.Text);
                    }
                    texts.Add(currRow);
                }
                rslt.Add(pg, texts);
            }
            return rslt;
        }
        public static int ExtractTableTexts(string[] args)
        {
            //Console.Read();
            string pdfPath = args[0];
            string rectsPath = args[1];
            string outputPath = args.Length > 2 && !string.IsNullOrWhiteSpace(args[2]) ? args[2] : null;
            var rects = ExtractTextByRectsWorker(pdfPath, rectsPath);
            if (string.IsNullOrWhiteSpace(outputPath)) Console.WriteLine("{0}", JsonConvert.SerializeObject(rects, Formatting.None));
            else File.WriteAllText(outputPath, JsonConvert.SerializeObject(ExtractTextsFromRectsWorker( rects), Formatting.None), Encoding.UTF8);
            return 0;
        }

        public static int ExtractTableStats(string[] args)
        {
            //Console.Read();
            string pdfPath = args[0];
            Console.WriteLine(JsonConvert.SerializeObject(TableTextStatsCompiler.Extract(pdfPath), Formatting.None));
            return 0;
        }

        public static int ExtractTableStatsBulk(string[] args)
        {
            string logsMask = args[0];
            string[] files = Directory.GetFiles(System.IO.Path.GetDirectoryName(logsMask), System.IO.Path.GetFileName(logsMask));
            List<ExtractedTableTextsStats> rslt = new List<ExtractedTableTextsStats>();
            foreach (string file in files)
            {
                rslt.Add(TableTextStatsCompiler.Extract(file));
            }
            Console.WriteLine(JsonConvert.SerializeObject(rslt, Formatting.None));
            return 0;
        }

        public static int GetSuspectedRowBreaksFromTableStats(string[] args)
        {
            string input = args[0];
            List<ExtractedTableTextsStats> stats = JsonConvert.DeserializeObject<List<ExtractedTableTextsStats>>(File.ReadAllText(input));
            var files = stats.Where(s => s.SuspectedCellPageBreaks > 0).ToList();
            Console.WriteLine(JsonConvert.SerializeObject(files, Formatting.None));
            return 0;
        }

        /// <summary>
        /// Incomplete, experimental
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        [Obsolete]
        public static int BuildCellsMatrix(string[] args)
        {
            Dictionary<int,List<RectangleInfoEx>> src = JsonConvert.DeserializeObject<Dictionary<int, List<RectangleInfoEx>>>(File.ReadAllText(args[0]));

            Dictionary<int, List<Tuple<int, int>>> matrices = new Dictionary<int, List<Tuple<int, int>>>();
            foreach (int pgi in src.Keys)
            {
                matrices.Add(pgi, (new Pdf2HtmlTablesConverter()).DetectTables(src[pgi]));
            }

            Console.WriteLine(JsonConvert.SerializeObject(matrices, Formatting.None));
            return 0;
        }
        #endregion

        #region Aux
        private static void LogCmdArgs(string methodName, string[] args)
        {
            StringBuilder sbArgs = new StringBuilder();
            sbArgs.AppendFormat("routed to method {0}(", methodName);
            if (args != null)
            {
                for (int i = 0; i < args.Length; i++)
                    sbArgs.AppendLine(string.Format("[{0}]: '{1}'", i, args[i]));
            }
            sbArgs.AppendLine(")");
            Console.WriteLine(sbArgs.ToString());
        }
        #endregion
    }
}
