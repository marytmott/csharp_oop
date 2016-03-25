using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CipherProgram;

namespace CaesarCipherTests
{
    [TestClass]
    public class CaesarCipherArrTests
    {
        private CaesarCipher testCipherArr;
        private ArrayBasedAlphabet abet;

        [TestInitialize]
        public void TestInitialize()
        {
            char[] alphabet = new char[27] { ' ', 'a', 'b', 'c', 'd', 'e', 'f', 'g',
                'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
                'u', 'v', 'w', 'x', 'y', 'z' };

            abet = new ArrayBasedAlphabet(alphabet);

            testCipherArr = new CaesarCipher(abet);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            testCipherArr = null;
        }

        [TestMethod]
        public void ShouldCipherCorrectly()
        {
            abet.Transpose(25);

            string message1 = "hello";
            string message2 = "how are you";

            string ciphered1 = testCipherArr.Cipher(message1);
            string ciphered2 = testCipherArr.Cipher(message2);

            byte[] charArr1 = new byte[5] { 129, 126, 133, 133, 136 };
            byte[] charArr2 = new byte[11] { 129, 136, 144, 57, 122, 139,
                126, 57, 146, 136, 142 };

            string expected1 = TestHelperMethods.ConvertToExpected(charArr1);
            string expected2 = TestHelperMethods.ConvertToExpected(charArr2);

            Assert.AreEqual(expected1, ciphered1);
            Assert.AreEqual(expected2, ciphered2);
        }

        [TestMethod]
        public void ShouldDecipherCorrectly()
        {
            abet.Transpose(230);

            byte[] charArr1 = new byte[5] { 79, 76, 83, 83, 86 };
            byte[] charArr2 = new byte[11] { 79, 86, 94, 7, 72, 89,
                76, 7, 96, 86, 92 };

            string ciphered1 = TestHelperMethods.ConvertToExpected(charArr1);
            string ciphered2 = TestHelperMethods.ConvertToExpected(charArr2);

            string deciphered1 = testCipherArr.Decipher(ciphered1);
            string deciphered2 = testCipherArr.Decipher(ciphered2);

            string expected1 = "hello";
            string expected2 = "how are you";

            Assert.AreEqual(expected1, deciphered1);
            Assert.AreEqual(expected2, deciphered2);
        }

        [TestMethod]
        public void CipherAndDecipherInOneTestForArrAbet()
        {
            abet.Transpose(256);

            string message = "this is a message test";

            string ciphered = testCipherArr.Cipher(message);
            string deciphered = testCipherArr.Decipher(ciphered);

            Assert.AreEqual(message, deciphered);
        }
    }
}
