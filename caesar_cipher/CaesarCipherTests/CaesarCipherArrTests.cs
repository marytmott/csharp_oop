using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CipherProgram;

namespace CaesarCipherTests
{
    [TestClass]
    public class CaesarCipherArrTests
    {
        CaesarCipher _testCipherArr;

        [TestInitialize]
        public void TestInitialize()
        {
            char[] alphabet = new char[27] { ' ', 'a', 'b', 'c', 'd', 'e', 'f', 'g',
                'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
                'u', 'v', 'w', 'x', 'y', 'z' };

            ArrayBasedAlphabet abet = new ArrayBasedAlphabet(alphabet);
            abet.Transpose(25);

            _testCipherArr = new CaesarCipher(abet);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _testCipherArr = null;
        }

        [TestMethod]
        public void ShouldCipherCorrectly()
        {
            string message1 = "hello";
            string message2 = "how are you";

            string ciphered1 = _testCipherArr.Cipher(message1);
            string ciphered2 = _testCipherArr.Cipher(message2);

            byte[] charArr1 = new byte[5] { 129, 126, 133, 133, 136 };
            byte[] charArr2 = new byte[11] { 129, 136, 144, 57, 122, 139,
                126, 57, 146, 136, 142 };

            string expected1 = TestHelperMethods.ConvertToExpected(charArr1);
            string expected2 = TestHelperMethods.ConvertToExpected(charArr2);

            Assert.AreEqual(expected1, ciphered1);
            Assert.AreEqual(expected2, ciphered2);
        }

        //[TestMethod]
        //public void ShouldDecipherCorrectly()
        //{
        //    string ciphered1 = "rovvy";
        //    string ciphered2 = "ryfjkaojhyd";

        //    string deciphered1 = _testCipherArr.Decipher(ciphered1);
        //    string deciphered2 = _testCipherArr.Decipher(ciphered2);

        //    string expected1 = "hello";
        //    string expected2 = "how are you";

        //    Assert.AreEqual(expected1, deciphered1);
        //    Assert.AreEqual(expected2, deciphered2);
        //}
    }
}
