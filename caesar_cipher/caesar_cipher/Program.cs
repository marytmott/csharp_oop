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

            // test offset
            string newAbet = testCipher.setOffset(15);
            Console.WriteLine(alphabet);
            Console.WriteLine(newAbet);

            // test cipher
            string message = "the dove arrives at noon";
            string ciphered = testCipher.cipher(message);
            Console.WriteLine(ciphered);

            // test decipher
            string deciphered = testCipher.decipher(ciphered);
            Console.WriteLine(deciphered);

            Console.ReadLine();
        }
    }

    public abstract class AAlphabet
    {
        public AAlphabet(char[] alphabet) { }

        public abstract void Transpose(int offset);

        public abstract char GetTransposedChar(char c);

    }

    public class DictionaryBasedAlphabet : AAlphabet
    {
        private char[] _alphabet;
        private Dictionary<char, char> _charMap;

        public DictionaryBasedAlphabet(char[] alphabet) : base(alphabet)
        {
            this._alphabet = alphabet;
            _charMap = new Dictionary<char, char>();
        }

        public override void Transpose(int offset)
        {
            int abetLength = _alphabet.Length;
            // transpose for length of alphabet
            for (int i = 0; i < abetLength; i++)
            {
                int currOffset = i + offset;

                if (currOffset >= abetLength)
                {
                    currOffset = currOffset - abetLength;
                }
                _charMap[_alphabet[i]] = _alphabet[currOffset];
            }
        }

        public override char GetTransposedChar(char c)
        {
            return _charMap[c];
        }
           
    }

    public class ArrayBasedAlphabet : AAlphabet
    {
        private char[] _alphabet;
        private char[] _charMap;

        public ArrayBasedAlphabet(char[] alphabet) : base(alphabet)
        {
            int charMapLength = alphabet.Length;

            this._alphabet = alphabet;
            _charMap = new char[charMapLength];
        }

        public override void Transpose(int offset)
        {
        }

    }

    public class CaesarCipher
    {
        // store in multi array
        private char[,] _alphabet;
        private char[,] _offsetAlphabet;

        // sets the offset alphabet
        // edge case for offset of 0?
        public string setOffset(int offsetAmount)
        {
            string newBeginning;
            string newEnding;
            int alphabetLength = this._alphabet.Length;

            if (offsetAmount == 0 || offsetAmount >= alphabetLength)
            {
                throw new ArgumentException("Invalid offset amount entered.");
            }

            newBeginning = _alphabet.Substring(offsetAmount);
            newEnding = _alphabet.Substring(0, offsetAmount);
            this._offsetAlphabet = newBeginning + newEnding;

            return this._offsetAlphabet;
        }

        // cypher a message
        public string cipher(string message)
        {
            string ciphered = "";

            for (int i = 0; i < message.Length; i++)
            {
                char currLetter = message[i];
                int idx = this._alphabet.IndexOf(currLetter);
                // dry this up w/ decipher
                if (idx == -1)
                {
                    throw new ArgumentException("Invalid character in message.");
                }
                ciphered += this._offsetAlphabet[idx];
            }
            return ciphered;
        }

        // decipher a message
        public string decipher(string message)
        {
            string deciphered = "";

            for (int i = 0; i < message.Length; i++)
            {
                char currLetter = message[i];
                int idx = this._offsetAlphabet.IndexOf(currLetter);
                // dry this up with above
                if (idx == -1)
                {
                    throw new ArgumentException("Invalid character in message.");
                }
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
