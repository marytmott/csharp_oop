using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipherTests
{
    public class TestHelperMethods
    {
        public static string ConvertToExpected(byte[] arr)
        {
            string output = "";

            foreach(byte charNum in arr)
            {
                output += Convert.ToChar(charNum);
            }
            return output;
        }
    }
}
