using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CipherProgram;

namespace CaesarCipherTests
{
    [TestClass]
    public class ArrayBasedAbetTests
    {
        private ArrayBasedAlphabet testAlphabet;

        [TestInitialize]
        public void TestInit()
        {
            char[] abet = new char[27] { ' ', 'a', 'b', 'c', 'd', 'e', 'f', 'g',
                'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
                'u', 'v', 'w', 'x', 'y', 'z' };
            testAlphabet = new ArrayBasedAlphabet(abet);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            testAlphabet = null;
        }

        [TestMethod]
        public void ShouldTransposeCorrectOffsetAmount()
        {
            testAlphabet.Transpose(5);
            char actual1 = testAlphabet.GetTransposedChar('f');

            Assert.AreEqual('a', actual1);

            // test edge case over 255 index
            testAlphabet.Transpose(240);
            char actual2 = testAlphabet.GetTransposedChar('c');

            Assert.AreEqual('r', actual2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Offset cannot be 0 or less than 0.")]
        public void ShouldThrowExceptionIfArgumentIsZero()
        {
            testAlphabet.Transpose(0);
            testAlphabet.Transpose(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Offset cannot be greater than 256.")]
        public void ShouldThrowExceptionIfArgumentIsGreaterThanAlphabetLength()
        {
            testAlphabet.Transpose(257);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Alphabet has not been transposed.")]
        public void ShouldThrowExceptionIfAlphabetHasNotBeenTransposed()
        {
            testAlphabet.GetTransposedChar('a');
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Char not found in alphabet transpose.")]
        public void ShouldThrowExceptionIfCharConversionNotInOriginalAlphabet()
        {
            testAlphabet.Transpose(15);

            testAlphabet.GetTransposedChar('!');
        }
    }
}
