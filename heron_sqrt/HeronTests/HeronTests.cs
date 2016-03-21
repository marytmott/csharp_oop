using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using heron_sqrt;

namespace HeronTests
{
    [TestClass]
    public class HeronTests
    {
        [TestMethod]
        public void Validate()
        {
            Heron heron = new Heron();
            Runtime sqrt = new Runtime();
            double errMargin = .0001;

            for (int i = 0; i < 10000; i++)
            {
                /// generate new random number
                Random rdm = new Random();
                double rdmNum = rdm.Next(0, 100000);

                /// get vals from both classes
                double hsqrt = heron.SquareRoot(rdmNum);
                double ssqrt = sqrt.SquareRoot(rdmNum);

                bool condition1 = hsqrt - ssqrt < errMargin;
                bool condition2 = ssqrt - hsqrt < errMargin;

                if (condition1)
                {
                    Assert.IsTrue(condition1);
                }
                else
                {
                    Assert.IsTrue(condition2);
                }
            }
        }
    }
}
