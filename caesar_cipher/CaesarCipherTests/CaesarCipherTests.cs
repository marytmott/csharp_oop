using Microsoft.VisualStudio.TestTools.UnitTesting;
using CaesarCipher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher.Tests
{
    [TestClass]
    public class CaesarCipherTests
    {
        string _alphabet;
        CaesarCipher _testCipher;

        [TestInitialize]
        public void TestInitialize()
        {
            _alphabet = " abcdefghijklmnopqrstuvwxyz";
            _testCipher = new CaesarCipher(_alphabet);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _alphabet = "";
            _testCipher = null;
        }

        [TestMethod]
        public void ShouldSetOffsetOfAlphabet()
        {
            string offsetAbet1 = _testCipher.setOffset(5);
            string offsetAbet2 = _testCipher.setOffset(20);
            string expected1 = "efghijklmnopqrstuvwxyz abcd";
            string expected2 = "tuvwxyz abcdefghijklmnopqrs";

            Assert.AreEqual(expected1, offsetAbet1);
            Assert.AreEqual(expected2, offsetAbet2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid offset amount entered.")]
        public void ShouldThrowExceptionIfArgumentIs0OrGreaterThanLengthOfAlphabet()
        {
            string offsetAbet0 = _testCipher.setOffset(0);
            string offsetAbetTooHigh = _testCipher.setOffset(1000);
        }

        [TestMethod]
        public void ShouldCipherMessage()
        {
            string message = "look out behind you lol not really";
            _testCipher.setOffset(5);
            string ciphered = _testCipher.cipher(message);
            string expected = "qttpetzyegjmnsiectzeqtqestyewjfqqc";

            Assert.AreEqual(expected, ciphered);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid character in message.")]
        public void ShouldThrowErrorIfInvalidCharInMessageToCipher()
        {
            string message = "when can we meet?";
            _testCipher.setOffset(5);
            string ciphered = _testCipher.cipher(message);
        }

        [TestMethod]
        public void ShouldDecipherMessage()
        {
            _testCipher.setOffset(15);
            string encoded = "hwtoscjtopffxjtgophobccb";
            string decoded = _testCipher.decipher(encoded);
            string expected = "the dove arrives at noon";

            Assert.AreEqual(expected, decoded);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid character in message.")]
        public void ShouldThrowErrorIfInvalidCharInMessageToDecipher()
        {
            string message = "when can we meet?";
            _testCipher.setOffset(5);
            string ciphered = _testCipher.cipher(message);
        }

        [TestMethod]
        public void ShouldCipherAndDecipherMessages()
        {
            _testCipher.setOffset(18);
            string message = "this is a test message to cipher";
            string ciphered = _testCipher.cipher(message);
            string deciphered = _testCipher.decipher(ciphered);

            Assert.AreEqual(message, deciphered);
        }
    }
}