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
            //int numOfErrs = 0;

            //try
            //{
            //    Validate.val();
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine("EXCEPTION: {0}", ex);
            //    numOfErrs++;
            //}
            //finally
            //{
            //    Console.WriteLine("Total number of errors: {0}", numOfErrs);
            //}
            //Console.ReadLine();
        }
    }

    // PART 2 Interface Requirement:
    interface ISqrRt
    {
        double SquareRoot(double d);
    }

    public class Heron : ISqrRt
    {
        public double SquareRoot(double d)
        {
            double guess = d / 2;
            double margin = .0001;
            /// Console.WriteLine("initial guess {0}", guess);

            /// check if arg is type int
            if (d.GetType() != typeof(double))
            {
                throw new ArgumentException("Argument must be a double type");
            }

            /// check if arg is positive
            if (d < 1)
            {
                throw new ArgumentException("Argument must be a positive value");
            }


            /// reset guess to try diff number

            while(true)
            {
                /// if guess is between the margins we want
                if (guess * guess > d - margin && guess * guess < d + margin)
                {
                    return guess;
                }
                /// or try again!
                guess = (guess + d / guess) / 2;

            }
        }

        public Heron() { }
    }

    public class Runtime : ISqrRt
    {
        public double SquareRoot(double d)
        {
            return Math.Sqrt(d);
        }

        public Runtime() { }
    }
}
