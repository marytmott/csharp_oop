using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heron_sqrt
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfErrs = 0;

            try
            {
                Validate.val();
            }
            catch(Exception ex)
            {
                Console.WriteLine("EXCEPTION: {0}", ex);
                numOfErrs++;
            }
            finally
            {
                Console.WriteLine("Total number of errors: {0}", numOfErrs);
            }
            Console.ReadLine();
        }
    }

    class Heron
    {
        public double SqRt(double num)
        {
            double guess = num / 2;
            double margin = .0001;
            /// Console.WriteLine("initial guess {0}", guess);

            /// check if arg is type int
            if (num.GetType() != typeof(double))
            {
                throw new ArgumentException("Argument must be a double type");
            }

            /// check if arg is positive
            if (num < 1)
            {
                throw new ArgumentException("Argument must be a positive value");
            }


            /// reset guess to try diff number

            while(true)
            {
                /// if guess is between the margins we want
                if (guess * guess > num - margin && guess * guess < num + margin)
                {
                    return guess;
                }
                /// or try again!
                guess = (guess + num / guess) / 2;

            }
        }

        public Heron() { }
    }

    class Sqrt
    {
        public double SqRt(double num)
        {
            return Math.Sqrt(num);
        }

        public Sqrt() { }
    }

    class Validate
    {
        public static void val()
        {
            Heron heron = new Heron();
            Sqrt sqrt = new Sqrt();
            double errMargin = .0001;

            for (int i = 0; i < 10000; i++)
            {
                /// generate new random number
                Random rdm = new Random();
                double rdmNum = rdm.Next(0, 100000);

                /// get vals from both classes
                double hsqrt = heron.SqRt(rdmNum);
                double ssqrt = sqrt.SqRt(rdmNum);

                if (hsqrt - ssqrt > errMargin || ssqrt - hsqrt > errMargin )
                {
                    throw new ApplicationException("Exceeded allowable calculation error margin.");
                }

            }
        }

    }
}
