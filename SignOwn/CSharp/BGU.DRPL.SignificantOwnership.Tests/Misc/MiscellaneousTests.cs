using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace BGU.DRPL.SignificantOwnership.Tests.Misc
{
    [TestFixture]
    public class MiscellaneousTests
    {
        [Test]
        public void AdditionFactorial100Test()
        {
            List<IntPair> successful = new List<IntPair>();
            for (int i = 1; i < 100; i++)
            {
                int currSum = 0;
                for (int j = i; j < 100 && currSum < 100; j++)
                {
                    currSum += j;
                    if (currSum == 100)
                    {
                        successful.Add(new IntPair() { First = i, Last = j});
                    }
                }
            }
            foreach (IntPair ipair in successful)
            {
                Console.WriteLine("{0}+...+{1}", ipair.First, ipair.Last);
            }
        }

        public class IntPair
        {
            public int First;
            public int Last;
        }
    }
}
