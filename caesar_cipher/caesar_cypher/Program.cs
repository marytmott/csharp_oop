using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caesar_cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            CaesarCipher testCipher = new CaesarCipher(alphabet);
            string newAbet = testCipher.setOffset(5);
            Console.WriteLine(newAbet);
            Console.ReadLine();
        }
    }

    class CaesarCipher
    {
        private string alphabet;
        private string offsetAlphabet;

        /// sets the offset alphabet
        public string setOffset(int offsetAmount)
        {
            string newBeginning;
            string newEnding;

            newBeginning = alphabet.Substring(offsetAmount);
            newEnding = alphabet.Substring(0, offsetAmount);
            this.offsetAlphabet = newBeginning + newEnding;

            return this.offsetAlphabet;
        }

        /// cypher a message
        //public string cipher(string message)
        //{
        //    //string ciphered;


        //}

        /// decipher a message
        //public string decipher(string message)
        //{

        //}
        
        public CaesarCipher(string alphabet)
        {
            this.alphabet = alphabet;
        }
    }
}
