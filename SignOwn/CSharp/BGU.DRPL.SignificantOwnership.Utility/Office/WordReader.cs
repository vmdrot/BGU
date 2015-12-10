using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BGU.DRPL.SignificantOwnership.Utility.Office
{
    public class WordReader : IDisposable
    {
        #region field(s)
        
        private Microsoft.Office.Interop.Word.Document _doc;
        Microsoft.Office.Interop.Word.Application _word;
        private string _docPath;
        #endregion

        protected Microsoft.Office.Interop.Word.Document Doc
        {
            get
            {
                if (_doc == null)
                {
                    if (string.IsNullOrEmpty(_docPath))
                        throw new ApplicationException("Please specify document.");
                    if( !File.Exists(_docPath))
                        throw new ApplicationException(string.Format("The document '{0}' doesn't exist.", _docPath));
                    if(_word ==null)
                        _word = new Microsoft.Office.Interop.Word.Application();
                    object miss = System.Reflection.Missing.Value;
                    object path = (object)_docPath;
                    object readOnly = true;
                    _doc = _word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
                }
                return _doc;
            }
        }

        public Dictionary<int, List<string>> ReadAllTables(string docPath)
        {
            Dictionary<int, List<string>> rslt = new Dictionary<int, List<string>>();
            _docPath = docPath;

            for (int i = 0; i < Doc.Tables.Count; i++)
            {
                int tIdx = i + 1;
                Microsoft.Office.Interop.Word.Table tbl = Doc.Tables[tIdx];
                Console.WriteLine(tbl.Range.Text.ToString());
                Console.WriteLine("--------------------------------------");
                Microsoft.Office.Interop.Word.Cells cells = tbl.Range.Cells;

                {
                    for (int c = 1; c <= cells.Count; c++)
                    {
                        AppendCellText(rslt, cells[c].RowIndex, cells[c].ColumnIndex - 1, cells[c].Range.Text.ToString());
                    }
                }

            }
            return rslt;
        }
        
        public Dictionary<int, Dictionary<int, List<string>>> ReadAllTablesEx(string docPath)
        {
            Dictionary<int, Dictionary<int, List<string>>> rslt = new Dictionary<int, Dictionary<int, List<string>>>();
            _docPath = docPath;

            for (int i = 0; i < Doc.Tables.Count; i++)
            {
                int tIdx = i + 1;
                Microsoft.Office.Interop.Word.Table tbl = Doc.Tables[tIdx];
                //Console.WriteLine(tbl.Range.Text.ToString());
                //Console.WriteLine("--------------------------------------");
                Dictionary<int, List<string>> currTbl = new Dictionary<int, List<string>>();
                Microsoft.Office.Interop.Word.Cells cells = tbl.Range.Cells;

                {
                    for (int c = 1; c <= cells.Count; c++)
                    {
                        AppendCellText(currTbl, cells[c].RowIndex, cells[c].ColumnIndex - 1, cells[c].Range.Text.ToString());
                    }
                }
                rslt.Add(tIdx, currTbl);

            }
            return rslt;
        }

        private void AppendCellText(Dictionary<int, List<string>> target, int r, int c, string val)
        {
            if (!target.ContainsKey(r))
                target.Add(r, new List<string>());
            EnsureListCount(target[r], c);
            target[r][c] = val;
        }

        private void EnsureListCount(List<string> list, int c)
        {
            while (list.Count <= c + 1)
                list.Add(string.Empty);
        }



        #region IDisposable Members

        private bool _disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void DisposeManagedResources()
        {
            if (_doc != null)
            {
                _doc.Close();
                _doc = null;
            }
            if (_word != null)
            {
                _word.Quit();
                _word = null;
            }
          
        }

        protected void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {

                    DisposeManagedResources();
                }

                _disposed = true;

            }
        }
        #endregion
    }
}
