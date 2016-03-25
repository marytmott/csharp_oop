using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CipherProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] alphabet = new char[27] { ' ', 'a', 'b', 'c', 'd', 'e', 'f', 'g',
                'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
                'u', 'v', 'w', 'x', 'y', 'z' };

            DictionaryBasedAlphabet abet = new DictionaryBasedAlphabet(alphabet);
            abet.Transpose(10);

            CaesarCipher testCipherDict = new CaesarCipher(abet);

            string message1 = "hello";
            string ciphered1 = testCipherDict.Cipher(message1);
            string deciphered1 = testCipherDict.Decipher(ciphered1);

            Console.ReadLine();

        }
    }

    public abstract class AAlphabet
    { 

        public AAlphabet(char[] alphabet) { }

        // cheater "getter"
        public abstract char CharMap(char c);

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

        public override char CharMap(char c)
        {
            return _charMap[c];
        }

        public override void Transpose(int offset)
        {
            int abetLength = _alphabet.Length;
            int currOffset;

            if (offset == 0)
            {
                throw new ArgumentException("Offset cannot be 0.");
            }

            if (offset > abetLength)
            {
                throw new ArgumentException("Offset cannot be greater than length of Alphabet.");
            }

            // transpose for length of alphabet
            for (int i = 0; i < abetLength; i++)
            {
                currOffset = i + offset;

                if (currOffset >= abetLength)
                {
                    currOffset = currOffset - abetLength;
                }
                _charMap[this._alphabet[i]] = this._alphabet[currOffset];
            }
        }

        public override char GetTransposedChar(char c)
        {
            // TODO - check if it is in alphabet! ?! here or cipher part?! 
            // throw error if not found?
            // make sure charmap exists? could not have transposed anything yet?
            //
            foreach (KeyValuePair<char, char> transposed in this._charMap)
            {
                if (transposed.Value == c)
                {
                    return transposed.Key;
                }
            }
            // make unit test for this?
            throw new KeyNotFoundException("Char not found in dictionary.");
        }
    }

    public class ArrayBasedAlphabet : AAlphabet
    {
        private char[] _alphabet;
        private char[] _charMap;
        private int _offset;
        // just convert to/from offset instead of storing (since you have to convert anyway when searching)

        public ArrayBasedAlphabet(char[] alphabet) : base(alphabet)
        {
            int abetLength = alphabet.Length;

            this._alphabet = alphabet;
            this._charMap = new char[256];
        }

        public override char CharMap(char c)
        {
            return this._charMap[c];
        }

        public override void Transpose(int offset)
        {
            int abetLength = this._alphabet.Length;
            int charMapIdx;
            int currOffset;
            char currentChar;
            char transposed;

            if (offset == 0)
            {
                throw new ArgumentException("Offset cannot be 0.");
            }

            if (offset > 256)
            {
                throw new ArgumentException("Offset cannot be greater than 256.");
            }

            this._offset = offset;
            
            // TODO - throw error if offset is 0?
            // does this need to check for null?
            for (int i = 0; i < abetLength; i++)
            {
                currentChar = _alphabet[i];
                charMapIdx = Convert.ToByte(currentChar);
                currOffset = charMapIdx + offset;

                if (currOffset >= 255)
                {
                    currOffset = currOffset - 255;
                }
                transposed = Convert.ToChar(currOffset);
                // DEBUGGING::
                //Console.WriteLine(charMapIdx);
                //Console.WriteLine(currOffset);
                //Console.WriteLine("--------");
                //bool isequal = Convert.ToChar(currOffset - this._offset) == currentChar;
                //Console.WriteLine(isequal);
                _charMap[charMapIdx] = transposed;
            }
        }

        public override char GetTransposedChar(char c)
        {
            // make sure charmap exists? could not have transposed anything yet?
            int charByte = Convert.ToByte(c);
            int transposedIdx = charByte - this._offset;
            char origAbetChar;

            if (transposedIdx < 0)
            {
                transposedIdx += 255;
            }
            origAbetChar = Convert.ToChar(transposedIdx);
            Console.WriteLine(origAbetChar);
            return origAbetChar;
        }
    }

    public class CaesarCipher
    {
        private AAlphabet _alphabet;

        public CaesarCipher(AAlphabet alphabet)
        {
            this._alphabet = alphabet;
        }

        public void setOffset(int offsetAmount)
        {
            _alphabet.Transpose(offsetAmount);
        }

        // cipher a message
        public string Cipher(string message)
        {
            string ciphered = "";
            char currLetter;

            for (int i = 0; i < message.Length; i++)
            {
                currLetter = message[i];
                ciphered += this._alphabet.CharMap(currLetter);
            }
            return ciphered;
        }

        // decipher a message
        public string Decipher(string message)
        {
            string deciphered = "";
            char currLetter;

            // TODO somewhere! --> throw new ArgumentException("Invalid character in message.");
            for (int i = 0; i < message.Length; i++)
            {
                currLetter = message[i];
                deciphered += this._alphabet.GetTransposedChar(currLetter);
                Console.WriteLine(deciphered);
            }
            return deciphered;
        }

    }
}
