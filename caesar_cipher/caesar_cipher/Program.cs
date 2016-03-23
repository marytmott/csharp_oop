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


            testAbet.Transpose(5);


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
            // TODO - check if it is in alphabet! ?! here or cipher part?! 
            // throw error if not found?
            return _charMap[c];
        }
    }

    public class ArrayBasedAlphabet : AAlphabet
    {
        private char[] _alphabet;
        private char[] _charMap;
        private int _offset;

        public ArrayBasedAlphabet(char[] alphabet) : base(alphabet)
        {
            int abetLength = alphabet.Length;

            this._alphabet = alphabet;
            _charMap = new char[abetLength];
        }

        public override void Transpose(int offset)
        {
            int abetLength = this._alphabet.Length;

            // encoding i for the offset ascii value

            if (offset == 0)
            {
                throw new ArgumentException("Offset cannot be 0.");
            }

            if (offset > abetLength)
            {
                throw new ArgumentException("Offset cannot be greater than alphabet Length.");
            }

            this._offset = offset;
            
            // TODO - throw error if offset is 0?
            // dry this up, used in dict as well
            // does this need to check for null?
            for (int i = 0; i < abetLength; i++)   // 256 is number of ascii elements
            {
                char currentOrig = _alphabet[i];
                int currOffset = i + offset;

                if (currOffset >= 256)
                {
                    currOffset = currOffset - 256;
                }
                _charMap[_alphabet[i]] = _alphabet[currOffset];
            }
        }

        public override char GetTransposedChar(char c)
        {
            int baseIdx = Convert.ToByte(c);
            int transposedIdx = baseIdx + this._offset;

            if (transposedIdx >= 256)
            {
                transposedIdx = transposedIdx - 256;
            }
            return _charMap[transposedIdx];
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
