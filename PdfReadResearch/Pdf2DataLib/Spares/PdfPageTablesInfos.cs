using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pdf2DataLib.Spares
{
    public class PdfPageTablesInfos
    {
        #region prop(s)
        public Dictionary<int, Tuple<float, float>> Rows { get; set; }
        public Dictionary<int, Tuple<float, float>> Cols { get; set; }
        public List<Tuple<int, int>> Rows2Cols { get; set; }
        public Dictionary<int, Tuple<List<int>,List<int>>> CandidateTables { get; set; }
        public Dictionary<int, RectangleInfoEx> PreliminaryTableOuterRects { get; internal set; }
        #endregion

        #region inner type(s)
        public class TableMatrixIds
        {
            public List<int> RowsIds { get; set; }
            public List<int> ColsIds { get; set; }
        }
        #endregion

    }
}
