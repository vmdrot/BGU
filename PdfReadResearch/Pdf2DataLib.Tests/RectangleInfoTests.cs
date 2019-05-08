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
            RectangleInfo one = new RectangleInfo() {ulx = 51.361f,uly = 418.765f,brx= 297.77002f,bry=354.43f};
            RectangleInfo two = new RectangleInfo() { ulx= 475.16f,uly= 340.03f,brx= 637.63f,bry= 305.59f};
            IsIntersectingTestWorker(one, two);
        }

        [Test]
        public void ShouldIntersect()
        {
            RectangleInfo one = new RectangleInfo() { ulx = 475.16f, uly = 340.03f, brx = 637.63f, bry = 305.59f };
            RectangleInfo two = new RectangleInfo() { ulx= 51.601f,uly= 340.03f,brx= 790.41f,bry= 51.509f};
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
    }
}
