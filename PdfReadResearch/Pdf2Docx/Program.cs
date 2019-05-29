using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pdf2Docx
{
    /// <summary>
    /// This blessing treasure we awe to https://code.msdn.microsoft.com/How-to-convert-PDF-to-DOCX-fc9e7186/
    /// </summary>
    class Program
    {
        static int Main(string[] args)
        {
            return Pdf2Docx(args);
        }

        public static int Pdf2Docx(string[] args)
        {
            string pdfFile = args[0];
            string wordFile = args[1];

            // Convert PDF file to DOCX file 
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

            f.OpenPdf(pdfFile);

            if (f.PageCount == 0)
                return 0;
            // You may choose output format between Docx and Rtf. 
            f.WordOptions.Format = SautinSoft.PdfFocus.CWordOptions.eWordDocument.Docx;

            int result = f.ToWord(wordFile);
            
            if (result == 0)
            {
                return 0;
            }
            return 1;
        }
    }
}
