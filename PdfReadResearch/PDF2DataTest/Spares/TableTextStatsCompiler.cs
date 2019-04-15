using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PDF2DataTest.Spares
{
    public static class TableTextStatsCompiler
    {
        //#region prop(s)
        //public Dictionary<int,List<List<string>>> Input { get; private set; }
        //#endregion

        //#region cctor(s)
        //public TableTextStatsCompiler()
        //{ }
        //#endregion

        public static ExtractedTableTextsStats Extract(string jsonPath)
        {
            ExtractedTableTextsStats rslt = Extract(JsonConvert.DeserializeObject<Dictionary<int, List<List<string>>>>(File.ReadAllText(jsonPath)));
            rslt.PdfPath = jsonPath;
            rslt.PdfName = Path.GetFileName(jsonPath);
            return rslt;
        }

        public static ExtractedTableTextsStats Extract(Dictionary<int, List<List<string>>> input)
        {
            ExtractedTableTextsStats rslt = new ExtractedTableTextsStats();
            rslt.PagesCount = input.Keys.Count;
            foreach (int pgi in input.Keys)
            {
                foreach (List<string> row in input[pgi])
                {
                    int? currColCnt = row?.Count;
                    if (currColCnt == null) continue;
                    int cc = (int)currColCnt;
                    if (!rslt.RowsByColumnCount.ContainsKey(cc))
                        rslt.RowsByColumnCount.Add(cc, 1);
                    else
                        rslt.RowsByColumnCount[cc]++;
                }
            }
            return rslt;
        }


    }
}
