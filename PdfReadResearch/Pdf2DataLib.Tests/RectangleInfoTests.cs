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
    public class RectangleInfoTests
    {
        [Test]
        public void ShouldntIntersect()
        {
            RectangleInfo one = new RectangleInfo() { ulx = 51.361f, uly = 418.765f, brx = 297.77002f, bry = 354.43f };
            RectangleInfo two = new RectangleInfo() { ulx = 475.16f, uly = 340.03f, brx = 637.63f, bry = 305.59f };
            IsIntersectingTestWorker(one, two);
        }

        [Test]
        public void ShouldIntersect()
        {
            RectangleInfo one = new RectangleInfo() { ulx = 475.16f, uly = 340.03f, brx = 637.63f, bry = 305.59f };
            RectangleInfo two = new RectangleInfo() { ulx = 51.601f, uly = 340.03f, brx = 790.41f, bry = 51.509f };
            IsIntersectingTestWorker(one, two);
        }

        [Test]
        public void ShouldntIntersect2()
        {
            RectangleInfo one = new RectangleInfo() { ulx = 51.361f, uly = 418.765f, brx = 297.77002f, bry = 354.43f };
            RectangleInfo two = new RectangleInfo() { ulx = 51.601f, uly = 340.03f, brx = 790.41f, bry = 51.509f };
            IsIntersectingTestWorker(one, two);
        }

        private void IsIntersectingTestWorker(RectangleInfo one, RectangleInfo two)
        {
            Console.WriteLine("{0}", RectangleInfo.IsIntersecting(one, two));
        }

        /*
        ShouldIntersect:
        */
        //a) same row, 2 cols vs 1 col
        [Test]
        public void SameRow2Colsvs1Col()
        {
            RectangleInfo sameRow2Cols = new RectangleInfo() { ulx = 0.0f, uly = 0.0f, brx = 100.00f, bry = 100.00f };
            RectangleInfo sameRow1Col = new RectangleInfo() { ulx = 0.0f, uly = 0.0f, brx = 50.00f, bry = 100.00f };
            Assert.IsTrue(RectangleInfo.IsIntersecting(sameRow2Cols, sameRow1Col));
        }

        //b) same col, 2 rows vs 1 row
        [Test]
        public void SameCol2Rowsvs1Row()
        {
            RectangleInfo sameCol2Rows = new RectangleInfo() { ulx = 0.0f, uly = 0.0f, brx = 100.00f, bry = 100.00f };
            RectangleInfo sameCol1Row = new RectangleInfo() { ulx = 0.0f, uly = 0.0f, brx = 100.00f, bry = 50.00f };
            Assert.IsTrue(RectangleInfo.IsIntersecting(sameCol2Rows, sameCol1Row));
        }

        //c) 2c x 2r vs 1c x 1r
        [Test]
        public void TwoColsx2Rowsvs1Col1Row()
        {
            RectangleInfo TwoColsx2Rows = new RectangleInfo() { ulx = 0.0f, uly = 0.0f, brx = 100.0f, bry = 100.0f };
            RectangleInfo OneCol1Row = new RectangleInfo() { ulx = 50.0f, uly = 50.0f, brx = 100.0f, bry = 100.0f };
            Assert.IsTrue(RectangleInfo.IsIntersecting(TwoColsx2Rows, OneCol1Row));
        }

        /*
        ShouldNotIntersect:
        */

        //a) same col, diff row
        [Test]
        public void SameColDiffRow()
        {
            RectangleInfo one = new RectangleInfo() { ulx = 0.0f, uly = 0.0f, brx = 100.0f, bry = 100.0f };
            RectangleInfo two = new RectangleInfo() { ulx = 0.0f, uly = 200.0f, brx = 100.0f, bry = 250.0f };
            Assert.IsFalse(RectangleInfo.IsIntersecting(one, two));
        }
        //b) same row, diff col
        [Test]
        public void SameRowDiffCol()
        {
            RectangleInfo one = new RectangleInfo() { ulx = 0.0f, uly = 0.0f, brx = 100.0f, bry = 100.0f };
            RectangleInfo two = new RectangleInfo() { ulx = 101.0f, uly = 0.0f, brx = 150.0f, bry = 100.0f };
            Assert.IsFalse(RectangleInfo.IsIntersecting(one, two));
        }
        //c) diff col, diff row
        [Test]
        public void DiffColDiffRow() {
            RectangleInfo one = new RectangleInfo() { ulx = 0.0f, uly = 0.0f, brx = 100.0f, bry = 100.0f };
            RectangleInfo two = new RectangleInfo() { ulx = 101.0f, uly = 101.0f, brx = 201.0f, bry = 201.0f };
            Assert.IsFalse(RectangleInfo.IsIntersecting(one, two));
        }

        //Shoud not:
        //{"Text":"Повне найменування банку: ","ulx":51.361,"uly":370.51,"brx":297.77002,"bry":418.765}
        //{"Text":"Місцезнаходження банку: ","ulx":51.361,"uly":354.43,"brx":297.77002,"bry":370.509979}
        [Test]
        public void SameColDiffRowRealLife()
        {
            RectangleInfo one = new RectangleInfo() { ulx = 51.361f, uly = 370.51f, brx = 297.77002f, bry = 418.765f };
            RectangleInfo two = new RectangleInfo() { ulx = 51.361f, uly = 354.43f, brx = 297.77002f, bry = 370.509979f };
            Assert.IsFalse(RectangleInfo.IsIntersecting(one, two));
        }

        [Test]
        public void RealLife_IsntWithin()
        {
            RectangleInfo one = new RectangleInfo() { ulx = 475.16f, uly = 340.03f, brx = 637.63f, bry = 305.59f };
            RectangleInfo two = new RectangleInfo() { ulx = 51.601f, uly = 340.03f, brx = 790.41f, bry = 51.509f };
            Assert.IsFalse(RectangleInfo.IsIntersecting(one, two));
        }

        [Test]
        public void RealLife_IsntWithin2()
        {
            RectangleInfo one = new RectangleInfo() { ulx = 475.16f, uly = 305.59f, brx = 637.63f, bry = 340.03f };
            RectangleInfo two = new RectangleInfo() { ulx = 51.601f, uly = 276.77f, brx = 790.41f, bry = 74.424f };
            Assert.IsFalse(RectangleInfo.IsIntersecting(one, two));
            
            
        }
    }

}

