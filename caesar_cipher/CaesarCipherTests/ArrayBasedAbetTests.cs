using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CipherProgram;

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
            char actual1 = _testAlphabet.GetTransposedChar('f');

            Assert.AreEqual('a', actual1);

            // test edge case over 255 index
            _testAlphabet.Transpose(240);
            char actual2 = _testAlphabet.GetTransposedChar('c');

            Assert.AreEqual('r', actual2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Offset cannot be 0.")]
        public void ShouldThrowExceptionIfArgumentIsZero()
        {
            _testAlphabet.Transpose(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Offset cannot be greater than 256.")]
        public void ShouldThrowExceptionIfArgumentIsGreaterThanAlphabetLength()
        {
            _testAlphabet.Transpose(257);
        }
    }
}
