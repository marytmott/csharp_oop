using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CaesarCipher;

namespace CaesarCipherTests
{
    [TestClass]
    public class ArrayBasedAbetTests
    {
        private ArrayBasedAlphabet _testAlphabet;

        [TestInitialize]
        public void TestInit()
        {
            char[] abet = new char[27] { ' ', 'a', 'b', 'c', 'd', 'e', 'f', 'g',
                'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
                'u', 'v', 'w', 'x', 'y', 'z' };
            _testAlphabet = new ArrayBasedAlphabet(abet);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _testAlphabet = null;
        }

        [TestMethod]
        public void ShouldTransposeCorrectOffsetAmount()
        {
            _testAlphabet.Transpose(5);

            char actual1 = _testAlphabet.GetTransposedChar('!');
            char actual2 = _testAlphabet.GetTransposedChar('a');
            //char twofiftyfive = Convert.ToChar(255);
            //char actual3 = _testAlphabet.GetTransposedChar(twofiftyfive);

            //char expected1 = Convert.ToChar(140);
            //char expected2 = Convert.ToChar(172);
            //char expected3 = Convert.ToChar(75);

            Assert.AreEqual('&', actual1);
            //Assert.AreEqual('f', actual2);
            //Assert.AreEqual(expected2, actual2);
            //Assert.AreEqual(expected3, actual3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Offset cannot be 0.")]
        public void ShouldThrowExceptionIfArgumentIsZero()
        {
            _testAlphabet.Transpose(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Offset cannot be greater than length of Alphabet")]
        public void ShouldThrowExceptionIfArgumentIsGreaterThanAlphabetLength()
        {
            _testAlphabet.Transpose(300);
        }
    }
}
