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
            char[] abet = new char[27] { ' ', 'a', 'b', 'c', 'd', 'e', 'f', 'g',
                'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
                'u', 'v', 'w', 'x', 'y', 'z' };

            ArrayBasedAlphabet testAbet = new ArrayBasedAlphabet(abet);
            testAbet.Transpose(240);
            char testGetChar = testAbet.GetTransposedChar('c');
            Console.WriteLine(testGetChar);

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
                _charMap[_alphabet[i]] = _alphabet[currOffset];
            }
        }

        public override char GetTransposedChar(char c)
        {
            // TODO - check if it is in alphabet! ?! here or cipher part?! 
            // throw error if not found?
            // make sure charmap exists? could not have transposed anything yet?

            return _charMap[c];
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
            // dry this up, used in dict as well
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

    //public class CaesarCipher
    //{
    //    // store in multi array
    //    private char[,] _alphabet;
    //    private char[,] _offsetAlphabet;

    //    // sets the offset alphabet
    //    // edge case for offset of 0?
    //    public string setOffset(int offsetAmount)
    //    {
    //        string newBeginning;
    //        string newEnding;
    //        int alphabetLength = this._alphabet.Length;

    //        if (offsetAmount == 0 || offsetAmount >= alphabetLength)
    //        {
    //            throw new ArgumentException("Invalid offset amount entered.");
    //        }

    //        newBeginning = _alphabet.Substring(offsetAmount);
    //        newEnding = _alphabet.Substring(0, offsetAmount);
    //        this._offsetAlphabet = newBeginning + newEnding;

    //        return this._offsetAlphabet;
    //    }

    //    // cypher a message
    //    public string cipher(string message)
    //    {
    //        string ciphered = "";

    //        for (int i = 0; i < message.Length; i++)
    //        {
    //            char currLetter = message[i];
    //            int idx = this._alphabet.IndexOf(currLetter);
    //            // dry this up w/ decipher
    //            if (idx == -1)
    //            {
    //                throw new ArgumentException("Invalid character in message.");
    //            }
    //            ciphered += this._offsetAlphabet[idx];
    //        }
    //        return ciphered;
    //    }

    //    // decipher a message
    //    public string decipher(string message)
    //    {
    //        string deciphered = "";

    //        for (int i = 0; i < message.Length; i++)
    //        {
    //            char currLetter = message[i];
    //            int idx = this._offsetAlphabet.IndexOf(currLetter);
    //            // dry this up with above
    //            if (idx == -1)
    //            {
    //                throw new ArgumentException("Invalid character in message.");
    //            }
    //            deciphered += this._alphabet[idx];
    //        }
    //        return deciphered;
    //    }

    //    public CaesarCipher(string alphabet)
    //    {
    //        this._alphabet = alphabet;
    //    }
    //}
}
