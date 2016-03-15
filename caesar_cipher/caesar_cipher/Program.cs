using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string alphabet = " abcdefghijklmnopqrstuvwxyz";
            CaesarCipher testCipher = new CaesarCipher(alphabet);

            /// test offset
            string newAbet = testCipher.setOffset(5);
            Console.WriteLine(alphabet);
            Console.WriteLine(newAbet);

            /// test cipher
            string message = "look out behind you lol not really";
            string ciphered = testCipher.cipher(message);
            Console.WriteLine(ciphered);

            /// test decipher
            string deciphered = testCipher.decipher(ciphered);
            Console.WriteLine(deciphered);

            Console.ReadLine();
        }
    }

    public class CaesarCipher
    {
        private string _alphabet;
        private string _offsetAlphabet;

        /// sets the offset alphabet
        /// edge case for offset of 0?
        public string setOffset(int offsetAmount)
        {
            string newBeginning;
            string newEnding;
            int alphabetLength = this._alphabet.Length;

            if (offsetAmount == 0 || offsetAmount > alphabetLength)
            {
                throw new ArgumentException("Invalid offset amount entered.");
            }


            newBeginning = _alphabet.Substring(offsetAmount);
            newEnding = _alphabet.Substring(0, offsetAmount);
            this._offsetAlphabet = newBeginning + newEnding;

            return this._offsetAlphabet;
        }

        /// cypher a message
        public string cipher(string message)
        {
            string ciphered = "";

            for (int i = 0; i < message.Length; i++)
            {
                char currLetter = message[i];
                int idx = this._alphabet.IndexOf(currLetter);
                ciphered += this._offsetAlphabet[idx];
            }
            return ciphered;
        }

        /// decipher a message
        public string decipher(string message)
        {
            string deciphered = "";

            for (int i = 0; i < message.Length; i++)
            {
                char currLetter = message[i];
                int idx = this._offsetAlphabet.IndexOf(currLetter);
                deciphered += this._alphabet[idx];
            }
            return deciphered;
        }

        public CaesarCipher(string alphabet)
        {
            this._alphabet = alphabet;
        }
    }
}
