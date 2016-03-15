using Microsoft.VisualStudio.TestTools.UnitTesting;
using CaesarCipher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher.Tests
{
    [TestClass()]
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
            _alphabet = String.Empty;
            _testCipher = null;
        }

        [TestMethod()]
        public void ShouldSetOffsetOfAlphabet()
        {
            string offsetAbet1 = _testCipher.setOffset(5);
            string offsetAbet2 = _testCipher.setOffset(20);

            Assert.AreEqual("efghijklmnopqrstuvwxyz abcd", offsetAbet1);
            Assert.AreEqual("tuvwxyz abcdefghijklmnopqrs", offsetAbet2);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "Invalid offset amount entered.")]
        public void ShouldThrowExceptionIfArgumentIs0OrGreaterThanLengthOfAlphabet()
        {
            string offsetAbet0 = _testCipher.setOffset(0);
            string offsetAbetTooHigh = _testCipher.setOffset(1000);
        }
    }
}