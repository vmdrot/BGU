using Pdf2DataLib.Spares;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public Dictionary<int, PdfPageTablesInfos.RowColInfo> DetectRows(List<RectangleInfoEx> src)
        {
            Dictionary<int, PdfPageTablesInfos.RowColInfo> rslt = new Dictionary<int, PdfPageTablesInfos.RowColInfo>();
            List<float> bryDistinct = new List<float>(src.Select(r => r.bry).Distinct().OrderByDescending(y => y));
            foreach (float bry in bryDistinct)
            {
                List<float> currUlys = src.Where(r => r.bry == bry).Select( r => r.uly).Distinct().OrderByDescending( y=> y).ToList();

                foreach (float y in currUlys)
                {
                    int currId = rslt.Count;
                    rslt.Add(currId, new PdfPageTablesInfos.RowColInfo() { Coord1 = bry, Coord2 = y, Id = currId });
                }
                
            }
            return rslt;
        }
        public Dictionary<int, PdfPageTablesInfos.RowColInfo> DetectColumns(List<RectangleInfoEx> src)
        {
            Dictionary<int, PdfPageTablesInfos.RowColInfo> rslt = new Dictionary<int, PdfPageTablesInfos.RowColInfo>();
            List<float> ulxDistinct = new List<float>(src.Select(r => r.ulx).Distinct().OrderBy(x => x));
            foreach (float ulx in ulxDistinct)
            {
                List<float> currBrxs = src.Where(r => r.ulx == ulx).Select(r => r.brx).Distinct().OrderBy(x => x).ToList();
                foreach (float x in currBrxs)
                {
                    int currId = rslt.Count;
                    rslt.Add(currId, new PdfPageTablesInfos.RowColInfo() { Coord1 = ulx, Coord2 = x, Id = currId });
                }                
            }
            return rslt;
        }

        public PdfPageTablesInfos  /*List<PdfTableInfo>*/ DetectTables(List<RectangleInfoEx> src)
        {
            //List<PdfTableInfo> rslt = new List<PdfTableInfo>();
            PdfPageTablesInfos rslt = new PdfPageTablesInfos();
            rslt.Rows = DetectRows(src);
            rslt.Cols = DetectColumns(src);


            rslt.Rows2Cols = DetectRows2ColumnsMatrices(rslt.Rows, rslt.Cols, src);
            rslt.CandidateTables = DetectCandidateTables(rslt);
            return rslt;
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

        private Dictionary<int, Tuple<List<int>, List<int>>> DetectCandidateTables(PdfPageTablesInfos target)
        {
            Dictionary<int, Tuple<List<int>, List<int>>> preliminaryRslt = new Dictionary<int, Tuple<List<int>, List<int>>>();
            Dictionary<int, int> rowsByTable = new Dictionary<int, int>();
            Dictionary<int, int> colsByTable = new Dictionary<int, int>();
            #region detect related rows
            foreach (int ri in target.Rows.Keys)
            {
                if (rowsByTable.ContainsKey(ri))
                    continue;
                List<int> relCols = target.Rows2Cols.Where(r2c => r2c.Item1 == ri).Select(r2c => r2c.Item2).Distinct().OrderBy( c => c).ToList();
                List<int> relRows = target.Rows2Cols.Where(r2c => relCols.Contains(r2c.Item2)).Select(r2c => r2c.Item1).Distinct().OrderBy(r => r).ToList();

                int? existingTableId = preliminaryRslt.Where(pr => pr.Value.Item1.Intersect(relRows).Any() || pr.Value.Item2.Intersect(relCols).Any()).FirstOrDefault().Key;
                int currTableId = existingTableId != null && existingTableId.Value > 0 ? (int)existingTableId : preliminaryRslt.Keys.Count + 1;
                foreach (int rc in relCols)
                {
                    if (!colsByTable.ContainsKey(rc))
                        colsByTable.Add(rc, currTableId);
                }
                foreach (int rr in relRows)
                {
                    if (!rowsByTable.ContainsKey(rr))
                        rowsByTable.Add(rr, currTableId);
                }
                if (!preliminaryRslt.ContainsKey(currTableId))
                    preliminaryRslt.Add(currTableId, new Tuple<List<int>, List<int>>(relRows, relCols));
                else
                {
                    var currVal = preliminaryRslt[currTableId];
                    foreach (int rr in relRows)
                    {
                        if (!currVal.Item1.Contains(rr))
                            currVal.Item1.Add(rr);
                    }
                    foreach (int rc in relCols)
                    {
                        if (!currVal.Item2.Contains(rc))
                            currVal.Item2.Add(rc);
                    }
                }
            }
            //return preliminaryRslt;
            #endregion
            //todo: detect preliminary result intersections and 'trim' it accordingly
            
            Dictionary<int, RectangleInfoEx> tableRects = DetectTableOuterRects(preliminaryRslt, target);
            target.PreliminaryTableOuterRects = tableRects;
            Dictionary<int, List<int>> duplicateRectKeys = new Dictionary<int, List<int>>();
            foreach (int ti in tableRects.Keys)
            {
                if (duplicateRectKeys.Any(dk => dk.Value.Contains(ti)))
                    continue;
                //var currDuplicates = tableRects.Where(tr => RectangleInfo.IsWithin(tableRects[ti], tr.Value) || RectangleInfo.IsWithin(tr.Value, tableRects[ti])).Select(tr => tr.Key).ToList();
                //var currDuplicates = tableRects.Where(tr => RectangleInfo.IsIntersecting(tableRects[ti], tr.Value) == true).Select(tr => tr.Key).ToList();
                List<int> currDuplicates = new List<int>();
                foreach (int key in tableRects.Keys)
                {
                    if (key == ti) continue;
                    if (RectangleInfo.IsIntersecting(tableRects[ti], tableRects[key]))
                        currDuplicates.Add(key);
                }
                if (currDuplicates != null && currDuplicates.Any())
                {
                    if (!duplicateRectKeys.ContainsKey(ti))
                        duplicateRectKeys.Add(ti, new List<int>());
                    duplicateRectKeys[ti].AddRange(currDuplicates);
                }
            }
            
            Dictionary<int, Tuple<List<int>, List<int>>> rslt = new Dictionary<int, Tuple<List<int>, List<int>>>();
            foreach (int ti in preliminaryRslt.Keys)
            {
                if (duplicateRectKeys.Any(dk => dk.Value.Contains(ti)))
                    continue;
                int currKey = rslt.Keys.Count + 1;
                rslt.Add(currKey, new Tuple<List<int>, List<int>>(preliminaryRslt[ti].Item1, preliminaryRslt[ti].Item2));
                if (duplicateRectKeys.ContainsKey(ti))
                {

                    foreach (int duplKey in duplicateRectKeys[ti])
                    {
                        AddRangeDistinct<int>(rslt[currKey].Item1, preliminaryRslt[duplKey].Item1);
                        AddRangeDistinct<int>(rslt[currKey].Item2, preliminaryRslt[duplKey].Item2);
                    }
                }
            }

            foreach (int key in rslt.Keys)
            {
                rslt[key].Item1.Sort();
                rslt[key].Item2.Sort();
            }
            return rslt;            
        }

        private Dictionary<int, RectangleInfoEx> DetectTableOuterRects(Dictionary<int, Tuple<List<int>, List<int>>> tableRowsCols, PdfPageTablesInfos target)
        {
            Dictionary<int, RectangleInfoEx> rslt = new Dictionary<int, RectangleInfoEx>();
            foreach (int ti in tableRowsCols.Keys)
            {

                float ulx = (new List<float>(from cols in target.Cols
                                             join colIds in tableRowsCols[ti].Item2 on cols.Key equals colIds
                                             select cols.Value.Coord1)).Min();
                float brx = (new List<float>(from cols in target.Cols
                                             join colIds in tableRowsCols[ti].Item2 on cols.Key equals colIds
                                             select cols.Value.Coord2)).Max();
                float uly = (new List<float>(from rows in target.Rows
                                             join rowIds in tableRowsCols[ti].Item1 on rows.Key equals rowIds
                                             select rows.Value.Coord1)).Max();
                float bry = (new List<float>(from rows in target.Rows
                                             join rowIds in tableRowsCols[ti].Item1 on rows.Key equals rowIds
                                             select rows.Value.Coord2)).Min();
                rslt.Add(ti, new RectangleInfoEx() { ulx = ulx, brx = brx, uly = uly, bry = bry });
            }
            return rslt;
        }

        private void AddRangeDistinct<T>(List<T> target, List<T> src)
        {
            foreach(T curr in src)
            {
                if (!target.Contains(curr))
                    target.Add(curr);
            }
        }


        //private Dictionary<int, List<Tuple<int, int>>> DetectCandidateTables(PdfPageTablesInfos target)
        //{
        //    Dictionary<int, List<Tuple<int, int>>> rslt = new Dictionary<int, List<Tuple<int, int>>>();
        //    foreach(var r in target.Rows)
        //}

        private List<Tuple<int, int>> DetectRows2ColumnsMatrices(Dictionary<int, PdfPageTablesInfos.RowColInfo> rows, Dictionary<int, PdfPageTablesInfos.RowColInfo> cols, List<RectangleInfoEx> src)
        {
            List<Tuple<int, int>> rslt = new List<Tuple<int, int>>();
            foreach (int rowIdx in rows.Keys)
            {
                List<RectangleInfoEx> currRowCells = src.Where(r => r.bry == rows[rowIdx].Coord1 && r.uly == rows[rowIdx].Coord2).ToList();
                foreach (int colIdx in cols.Keys)
                {
                    if (currRowCells.Any(r => r.ulx == cols[colIdx].Coord1 && r.brx == cols[colIdx].Coord2))
                        rslt.Add(new Tuple<int, int>(rowIdx, colIdx));
                }
            }
            return rslt;
        }
    }
}
