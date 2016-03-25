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
        }

        public override char CharMap(char c)
        {
            return _charMap[c];
        }

        public override void Transpose(int offset)
        {
            int abetLength = _alphabet.Length;
            int currOffset;

            if (offset <= 0)
            {
                throw new ArgumentOutOfRangeException("Offset cannot be 0 or less than 0.");
            }

            if (offset > abetLength)

            {
                throw new ArgumentOutOfRangeException("Offset cannot be greater than length of Alphabet.");
            }

            _charMap = new Dictionary<char, char>();

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

            if (this._charMap.Equals(null))
            {
                throw new NullReferenceException("Alphabet has not been transposed.");
            }
   
            foreach (KeyValuePair<char, char> transposed in this._charMap)
            {
                if (transposed.Value == c)
                {
                    return transposed.Key;
                }
            }
            throw new KeyNotFoundException("Char not found in dictionary.");
        }
    }

    public class ArrayBasedAlphabet : AAlphabet
    {
        private char[] _alphabet;
        private char[] _charMap;
        private int _offset;
        // just convert to/from offset instead of storing (since you have to convert anyway when searching) ?

        public ArrayBasedAlphabet(char[] alphabet) : base(alphabet)
        {
            int abetLength = alphabet.Length;

            this._alphabet = alphabet;
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

            if (offset <= 0)
            {
                throw new ArgumentOutOfRangeException("Offset cannot be 0 or less than 0.");
            }

            if (offset > 256)
            {
                throw new ArgumentOutOfRangeException("Offset cannot be greater than 256.");
            }

            this._charMap = new char[256];
            this._offset = offset;
            
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
                _charMap[charMapIdx] = transposed;
            }
        }

        public override char GetTransposedChar(char c)
        {
            int charByte;
            int transposedIdx;
            char origAbetChar;

            if (this._charMap.Equals(null))
            {
                throw new NullReferenceException("Alphabet has not been transposed.");
            }

            charByte = Convert.ToByte(c);
            transposedIdx = charByte - this._offset;

            if (transposedIdx < 0)
            {
                transposedIdx += 255;
            }

            origAbetChar = Convert.ToChar(transposedIdx);

            // because this converts any byte val to ascii, need to check if converted
            // was in original alphabet:
            if (Array.IndexOf(this._alphabet, origAbetChar) == -1)
            {
                throw new ArgumentException("Char not found in alphabet transpose.");
            }

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

            for (int i = 0; i < message.Length; i++)
            {
                currLetter = message[i];
                deciphered += this._alphabet.GetTransposedChar(currLetter);
            }
            return deciphered;
        }

    }
}
