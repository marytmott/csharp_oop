using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CipherProgram;

namespace CaesarCipherTests
{
    [TestClass]
    public class CaesarCipherDictTests
    {
        CaesarCipher _testCipherDict;

        [TestInitialize]
        public void TestInitialize()
        {
            char[] alphabet = new char[27] { ' ', 'a', 'b', 'c', 'd', 'e', 'f', 'g',
                'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
                'u', 'v', 'w', 'x', 'y', 'z' };

            DictionaryBasedAlphabet abet = new DictionaryBasedAlphabet(alphabet);
            abet.Transpose(10);

            _testCipherDict = new CaesarCipher(abet);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _testCipherDict = null;
        }

        [TestMethod]
        public void ShouldCipherCorrectly()
        {
            string message1 = "hello";
            string message2 = "how are you";

            string ciphered1 = _testCipherDict.Cipher(message1);
            string ciphered2 = _testCipherDict.Cipher(message2);

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

            string deciphered1 = _testCipherDict.Decipher(ciphered1);
            string deciphered2 = _testCipherDict.Decipher(ciphered2);

            string expected1 = "hello";
            string expected2 = "how are you";

            Assert.AreEqual(expected1, deciphered1);
            Assert.AreEqual(expected2, deciphered2);
        }

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentException), "Invalid offset amount entered.")]
        //public void ShouldThrowExceptionIfArgumentIs0OrGreaterThanLengthOfAlphabet()
        //{
        //    string offsetAbet0 = _testCipher.setOffset(0);
        //    string offsetAbetTooHigh = _testCipher.setOffset(1000);
        //}

        //[TestMethod]
        //public void ShouldCipherMessage()
        //{
        //    string message = "look out behind you lol not really";
        //    _testCipher.setOffset(5);
        //    string ciphered = _testCipher.cipher(message);
        //    string expected = "qttpetzyegjmnsiectzeqtqestyewjfqqc";

        //    Assert.AreEqual(expected, ciphered);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentException), "Invalid character in message.")]
        //public void ShouldThrowErrorIfInvalidCharInMessageToCipher()
        //{
        //    string message = "when can we meet?";
        //    _testCipher.setOffset(5);
        //    string ciphered = _testCipher.cipher(message);
        //}

        //[TestMethod]
        //public void ShouldDecipherMessage()
        //{
        //    _testCipher.setOffset(15);
        //    string encoded = "hwtoscjtopffxjtgophobccb";
        //    string decoded = _testCipher.decipher(encoded);
        //    string expected = "the dove arrives at noon";

        //    Assert.AreEqual(expected, decoded);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentException), "Invalid character in message.")]
        //public void ShouldThrowErrorIfInvalidCharInMessageToDecipher()
        //{
        //    string message = "when can we meet?";
        //    _testCipher.setOffset(5);
        //    string ciphered = _testCipher.cipher(message);
        //}

        //[TestMethod]
        //public void ShouldCipherAndDecipherMessages()
        //{
        //    _testCipher.setOffset(18);
        //    string message = "this is a test message to cipher";
        //    string ciphered = _testCipher.cipher(message);
        //    string deciphered = _testCipher.decipher(ciphered);

        //    Assert.AreEqual(message, deciphered);
        //}
    }
}