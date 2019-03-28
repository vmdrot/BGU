using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace PDFReader
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
            _cmdHandlers.Add(string.Empty, Readv3);
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
                _cmdHandlers[keyArg](origArgs.ToArray());
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

        public static void ReadPDFTablev2(string[] args)
        {
            var lst = Readv2(args[0]);
            foreach (string ln in lst)
                Console.WriteLine(ln);
        }

        public static void ReadPDFTable(string[] args)
        {
            string pdfPath = args[0];
            int pageIdx = int.Parse(args[1]);
            Rectangle argsRect = null;
            if (args.Length > 2 && !string.IsNullOrWhiteSpace(args[2]))
            {
                float[] pts = Newtonsoft.Json.JsonConvert.DeserializeObject<float[]>(string.Format("[{0}]", args[2]));
                if (pts != null && pts.Length == 4)
                    argsRect = new Rectangle(pts[0], pts[1], pts[2], pts[3]);
            }
            //Console.Read();
            using (PdfReader reader = new PdfReader(pdfPath))
            {
                Rectangle rect = argsRect != null ? argsRect : new Rectangle(36, 750, 559, 806);
                RenderFilter regionFilter = new RegionTextRenderFilter(rect);
                //RenderFilter tableFilter = new iTextSharp.text.pdf.parser.t
                Console.WriteLine("reader.NumberOfPages: {0}", reader.NumberOfPages);
                Console.WriteLine("reader.PdfVersion: {0}", reader.PdfVersion);
                Console.WriteLine("reader.FileLength: {0}", reader.FileLength);
                PdfDictionary page1 = reader.GetPageN(pageIdx);
                Console.WriteLine("page1.Length: {0}, page1.Keys.Count: {1}", page1.Length, page1.Keys.Count);
                //for (int i = 0; i < page1.Length; i++)
                //{

                //}
                foreach (var key in page1.Keys)
                {
                    Console.WriteLine("[{0}, {1}, {2}]: {3}", key.ToString(), key.Type, key.Length, page1.Get(key).Type);
                    if (page1.Get(key).IsString())
                        Console.WriteLine(System.Text.Encoding.UTF8.GetString(page1.Get(key).GetBytes()));
                    PdfObject pdfObj = page1.Get(key);
                    
                }
                //FontRenderFilter fontFilter = new FontRenderFilter();
                ITextExtractionStrategy strategy = new FilteredTextRenderListener(
                        new LocationTextExtractionStrategy(), regionFilter);
                Console.WriteLine("Text within rect: '{0}'", PdfTextExtractor.GetTextFromPage(reader, 1, strategy));
            }
        }

        //see https://stackoverflow.com/questions/15679958/how-to-read-table-from-pdf-using-itextsharp
        public static List<String> Readv2(string pdfPath)
        {
            using (var pdfReader = new PdfReader(pdfPath))
            {
                var pages = new List<String>();

                for (int i = 0; i < pdfReader.NumberOfPages; i++)
                {
                    string textFromPage = Encoding.UTF8.GetString(Encoding.Convert(Encoding.Default, Encoding.UTF8, pdfReader.GetPageContent(i + 1)));

                    pages.Add(GetDataConvertedData(textFromPage));
                }

                return pages;
            }
        }

        private static string GetDataConvertedData(string textFromPage)
        {
            var texts = textFromPage.Split(new[] { "\n" }, StringSplitOptions.None)
                                    .Where(text => text.Contains("Tj")).ToList();

            return texts.Aggregate(string.Empty, (current, t) => current +
                       t.TrimStart('(')
                        .TrimEnd('j')
                        .TrimEnd('T')
                        .TrimEnd(')'));
        }

        public static void Readv3(string[] args)
        {
            using (var pdfReader = new PdfReader(args[0]))
            {
                for (int i = 0; i < pdfReader.NumberOfPages; i++)
                {
                    var locationTextExtractionStrategy = new LocationTextExtractionStrategy();

                    string textFromPageEnc = PdfTextExtractor.GetTextFromPage(pdfReader, i + 1, locationTextExtractionStrategy);
                    //PdfPTable pdfPTable;
                    //PdfPTableBody;
                    //PdfPTableFooter;
                    //PdfPTableHeader;
                    var pgres = pdfReader.GetPageResources(i + 1);
                    foreach (var key in pgres.Keys)
                    {
                        
                        var currOfj = pgres.Get(key);
                        byte[] currBytes = currOfj.GetBytes();

                        Console.WriteLine("'{0}': {1}", key, currBytes != null ? string.Format("'{0}'",Encoding.UTF8.GetString(Encoding.Convert(Encoding.Default, Encoding.UTF8, currBytes))) : "null");
                    }
                    Console.WriteLine(new string('-', 20));
                    Console.WriteLine("pgres = {0}", Newtonsoft.Json.JsonConvert.SerializeObject(pgres, Newtonsoft.Json.Formatting.None));
                    Console.WriteLine(new string('-', 20));
                    string textFromPage = Encoding.UTF8.GetString(Encoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(textFromPageEnc)));

                    Console.WriteLine(textFromPage);
                    Console.WriteLine(new string('=', 20));
                }
            }

        }

        private static void SplitPDF(string[] args)
        {
            string srcPdfPath = args[0];
            using (PdfReader r = new PdfReader(srcPdfPath))
            {
                using (PdfDocument pdfDoc = new PdfDocument())
                {
                    //var splitDocuments = new PdfSplitter
                    //todo
                }
            }
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
