using Pdf2DataLib.Spares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pdf2DataLib
{
    public class Pdf2HtmlTablesConverter
    {

        #region inner type(s)

        #endregion
        /*
        public Dictionary<int,List<string>> ToHtmlTables(Dictionary<int, List<RectangleInfoEx>> src)
        {
            Dictionary<int, List<string>> rslt = new Dictionary<int, List<string>>();

            foreach (int pgIdx in src.Keys)
            {
                rslt.Add(pgIdx, Page2HtmlTables(pgIdx, src[pgIdx]));
            }

            return rslt;
        }

        public List<string> Page2HtmlTables(int pgIdx, List<RectangleInfoEx> rectXs)
        {
            List<PdfTableInfo> tbls = DetectTables(rectXs);
            return null; //todo
        }
        */
        public Dictionary<int, Tuple<float, float>> DetectRows(List<RectangleInfoEx> src)
        {
            Dictionary<int, Tuple<float, float>> rslt = new Dictionary<int, Tuple<float, float>>();
            List<float> bryDistinct = new List<float>(src.Select(r => r.bry).Distinct().OrderByDescending(y => y));
            foreach (float bry in bryDistinct)
            {
                List<float> currUlys = src.Where(r => r.bry == bry).Select( r => r.uly).Distinct().OrderByDescending( y=> y).ToList();
                foreach (float y in currUlys)
                    rslt.Add(rslt.Count, new Tuple<float, float>(bry, y));
            }
            return rslt;
        }
        public Dictionary<int, Tuple<float, float>> DetectColumns(List<RectangleInfoEx> src)
        {
            Dictionary<int, Tuple<float, float>> rslt = new Dictionary<int, Tuple<float, float>>();
            List<float> ulxDistinct = new List<float>(src.Select(r => r.ulx).Distinct().OrderBy(x => x));
            foreach (float ulx in ulxDistinct)
            {
                List<float> currBrxs = src.Where(r => r.ulx == ulx).Select(r => r.brx).Distinct().OrderBy(x => x).ToList();
                foreach (float x in currBrxs)
                    rslt.Add(rslt.Count, new Tuple<float, float>(ulx, x));
            }
            return rslt;
        }

        public List<Tuple<int, int>> /*List<PdfTableInfo>*/ DetectTables(List<RectangleInfoEx> src)
        {
            List<PdfTableInfo> rslt = new List<PdfTableInfo>();
            var rows = DetectRows(src);
            var cols = DetectColumns(src);


            List<Tuple<int, int>> rows2Cols = DetectRows2ColumnsMatrices(rows, cols, src);
            return rows2Cols;
            //Dictionary<int, List<int>> rowGroups = DetectRowGroups(rows);
            /*
            Dictionary<float, List<RectangleInfoEx>> rectsByRows = new Dictionary<float, List<RectangleInfoEx>>();
            foreach(float bry in bryDistinct)
            {
                rectsByRows.Add(-1 * bry, src.Where(r => r.bry == bry).OrderBy(r => r.ulx).ToList());
            }
            PdfTableInfo currTable = new PdfTableInfo();
            foreach (float bry in rectsByRows.Keys)
            {
               //todo
            }
            return rslt;*/


        }

        private List<Tuple<int, int>> DetectRows2ColumnsMatrices(Dictionary<int, Tuple<float, float>> rows, Dictionary<int, Tuple<float, float>> cols, List<RectangleInfoEx> src)
        {
            List<Tuple<int, int>> rslt = new List<Tuple<int, int>>();
            foreach (int rowIdx in rows.Keys)
            {
                List<RectangleInfoEx> currRowCells = src.Where(r => r.bry == rows[rowIdx].Item1 && r.uly == rows[rowIdx].Item2).ToList();
                foreach (int colIdx in cols.Keys)
                {
                    if (currRowCells.Any(r => r.ulx == cols[colIdx].Item1 && r.brx == cols[colIdx].Item2))
                        rslt.Add(new Tuple<int, int>(rowIdx, colIdx));
                }
            }
            return rslt;
        }
    }
}
