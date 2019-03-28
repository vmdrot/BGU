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

namespace PDF2DataTest
{
    class Program
    {
        #region field(s)
        private static Dictionary<string, CmdHandler> _cmdHandlers;
        #endregion

        #region inner type(s)
        private delegate void CmdHandler(string[] args);
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
                if (mi.ReturnType != typeof(void))
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
        public static void Main(string[] args)
        {
            FillCmdHandlers();
            string keyArg = args.Length > 0 ? args[0].ToLower() : null;
            if (!string.IsNullOrWhiteSpace(keyArg) && _cmdHandlers.ContainsKey(keyArg))
            {
                List<string> origArgs = new List<string>(args);
                origArgs.RemoveAt(0);
                LogCmdArgs(_cmdHandlers[keyArg].Method.Name, origArgs.ToArray());
                try { _cmdHandlers[keyArg](origArgs.ToArray()); } catch (Exception ex) { Console.WriteLine(ex); }
            }
            else
                _cmdHandlers[string.Empty](args);
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
        public static void ResearchTableEvents(string[] args)
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
        }

        public static void ExtractTableRectangles(string[] args)
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
                        listener.Chatty = false;
                        parser.ProcessContent(pg, listener);
                        List<PathInfo> pathInfos = listener.GetClippingPaths();
                        rects.Add(pg, PdfTableHelper.ClippingPaths2RectangleInfosDistinct(pathInfos));
                    }

                    Console.WriteLine("{0}", JsonConvert.SerializeObject(rects, Formatting.None), rects.Count);
                }
            }
        }

        public static void ExtractTextByRects(string[] args)
        {
            string pdfPath = args[0];
            string rectsPath = args[1];
            string outputPath = args.Length > 2 && !string.IsNullOrWhiteSpace(args[2]) ? args[2] : null;
            Dictionary<int, List<RectangleInfoEx>> rects = JsonConvert.DeserializeObject<Dictionary<int, List<RectangleInfoEx>>>(File.ReadAllText(rectsPath), new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            using (iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(pdfPath))
            {
                foreach (int pg in rects.Keys)
                {
                    for(int i = 0; i < rects[pg].Count; i++)
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

            if (string.IsNullOrWhiteSpace(outputPath)) Console.WriteLine("{0}", JsonConvert.SerializeObject(rects, Formatting.None));
            else File.WriteAllText(outputPath, JsonConvert.SerializeObject(rects, Formatting.None), Encoding.UTF8);
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
