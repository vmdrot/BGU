using Newtonsoft.Json;
using NUnit.Framework;
using Pdf2DataLib.Spares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pdf2DataLib.Tests
{
    [TestFixture]
    public class DetectTablesTests
    {
        [Test]
        public void RectsTexts_300012_20150308()
        {
            RectsTexts_Worker(@"F:\home\vmdrot\Testing\OpenData\Output\BGU\328\300012_20150308.pdf", new Dictionary<int, int> { { 1, 39 }, { 2, 163 }, { 3, 56 } });
        }

        private void RectsTexts_Worker(string pdfPath, Dictionary<int,int> expectedLengthByPages)
        {
            var rects = PDF2DataTest.Program.ExtractTableRectangles_Worker(pdfPath, true, false);
            string rectsJson = JsonConvert.SerializeObject(rects, Formatting.None);
            var rectsTexts = PDF2DataTest.Program.ExtractTextByRectsWorker(pdfPath, 
                JsonConvert.DeserializeObject<Dictionary<int, List<RectangleInfoEx>>>(rectsJson));
            int discrCnt = 0;
            foreach(var pg in rectsTexts.Keys)
            {
                if (!expectedLengthByPages.ContainsKey(pg))
                    continue;
                if (rectsTexts[pg].Count != expectedLengthByPages[pg])
                {
                    discrCnt++;
                    Console.WriteLine("discrepancy:[{0}] {1} vs {2} exp", pg, rectsTexts[pg].Count, expectedLengthByPages[pg]);
                }
            }
            Assert.AreEqual(discrCnt, 0, string.Format("{0}", discrCnt == 0 ? "passed" : "failed"));
        }
    }
}
