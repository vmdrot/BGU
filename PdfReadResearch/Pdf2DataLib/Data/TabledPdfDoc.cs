using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pdf2DataLib.Data
{
    public class TabledPdfDoc
    {
        public int PagesCount { get; set; }
        Dictionary<int, List<List<string>>> TablesByPages { get; set; }
        Dictionary<int, string> TextsByPages { get; set; }
    }
}
