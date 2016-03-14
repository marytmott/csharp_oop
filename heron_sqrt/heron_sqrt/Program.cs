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
            double sr = Heron.SquareRoot(10);

        }
    }

    class Heron
    {

        public static double SquareRoot(double num)
        {
            double guess = num / 2;
            double margin = 1;
            Console.WriteLine("initial guess {0}", guess);

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

            if (guess * guess > num - margin && guess * guess < num + margin)
            {
                Console.WriteLine("guessed right! {0}", guess);
                Console.ReadLine();
                return guess;
            }

            /// reset guess to try diff number'

            guess = (guess + num / guess) / 2;
            
            Console.WriteLine("calling again {0}", guess);
            return Heron.SquareRoot(guess);
        }
    }
}
