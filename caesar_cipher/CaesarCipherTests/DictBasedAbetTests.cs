using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CipherProgram;

namespace CaesarCipherTests
{
    [TestClass]
    public class DictBasedAbetTests
    {
        private DictionaryBasedAlphabet testAlphabet;

        [TestInitialize]
        public void TestInit()
        {
            char[] abet = new char[27] { ' ', 'a', 'b', 'c', 'd', 'e', 'f', 'g',
                'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
                'u', 'v', 'w', 'x', 'y', 'z' };
            testAlphabet = new DictionaryBasedAlphabet(abet);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            testAlphabet = null;
        }

        [TestMethod]
        public void ShouldTransposeCorrectOffsetAmount()
        {
            testAlphabet.Transpose(10);

            char actual1 = testAlphabet.GetTransposedChar(' ');
            char actual2 = testAlphabet.GetTransposedChar('d');
            char actual3 = testAlphabet.GetTransposedChar('z');

            Assert.AreEqual('q', actual1);
            Assert.AreEqual('u', actual2);
            Assert.AreEqual('p', actual3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Offset cannot be 0 or less than 0.")]
        public void ShouldThrowExceptionIfArgumentIsZero()
        {
            testAlphabet.Transpose(0);
            testAlphabet.Transpose(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Offset cannot be greater than length of Alphabet.")]
        public void ShouldThrowExceptionIfArgumentIsGreaterThanAlphabetLength()
        {
            testAlphabet.Transpose(28);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Alphabet has not been transposed.")]
        public void ShouldThrowErrorIfAlphabetHasNotBeenTransposed()
        {
            testAlphabet.GetTransposedChar('a');
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "Char not found in dictionary.")]
        public void ShouldThrowExceptionIfCharNotFoundInCharMap()
        {
            testAlphabet.Transpose(9);
            testAlphabet.GetTransposedChar('!');
        }
    }
}
