using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CipherProgram;

namespace CaesarCipherTests
{
    [TestClass]
    public class CaesarCipherDictTests
    {
        CaesarCipher testCipherDict;

        [TestInitialize]
        public void TestInitialize()
        {
            char[] alphabet = new char[27] { ' ', 'a', 'b', 'c', 'd', 'e', 'f', 'g',
                'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
                'u', 'v', 'w', 'x', 'y', 'z' };

            DictionaryBasedAlphabet abet = new DictionaryBasedAlphabet(alphabet);
            abet.Transpose(10);

            testCipherDict = new CaesarCipher(abet);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            testCipherDict = null;
        }

        [TestMethod]
        public void ShouldCipherCorrectly()
        {
            string message1 = "hello";
            string message2 = "how are you";

            string ciphered1 = testCipherDict.Cipher(message1);
            string ciphered2 = testCipherDict.Cipher(message2);

            string expected1 = "rovvy";
            string expected2 = "ryfjkaojhyd";

            Assert.AreEqual(expected1, ciphered1);
            Assert.AreEqual(expected2, ciphered2);
        }

        [TestMethod]
        public void ShouldDecipherCorrectly()
        {
            string ciphered1 = "rovvy";
            string ciphered2 = "ryfjkaojhyd";

            string deciphered1 = testCipherDict.Decipher(ciphered1);
            string deciphered2 = testCipherDict.Decipher(ciphered2);

            string expected1 = "hello";
            string expected2 = "how are you";

            Assert.AreEqual(expected1, deciphered1);
            Assert.AreEqual(expected2, deciphered2);
        }

        [TestMethod]
        public void CipherAndDecipherInOneTestForDictAbet()
        {
            string message = "this is a message test";

            string ciphered = testCipherDict.Cipher(message);
            string deciphered = testCipherDict.Decipher(ciphered);

            Assert.AreEqual(message, deciphered);
        }
    }
}