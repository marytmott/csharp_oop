using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CipherProgram;

namespace CaesarCipherTests
{
    [TestClass]
    public class DictBasedAbetTests
    {
        private DictionaryBasedAlphabet _testAlphabet;

        [TestInitialize]
        public void TestInit()
        {
            char[] abet = new char[27] { ' ', 'a', 'b', 'c', 'd', 'e', 'f', 'g',
                'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
                'u', 'v', 'w', 'x', 'y', 'z' };
            _testAlphabet = new DictionaryBasedAlphabet(abet);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _testAlphabet = null;
        }

        [TestMethod]
        public void ShouldTransposeCorrectOffsetAmount()
        {
            _testAlphabet.Transpose(10);

            char actual1 = _testAlphabet.GetTransposedChar(' ');
            char actual2 = _testAlphabet.GetTransposedChar('d');
            char actual3 = _testAlphabet.GetTransposedChar('z');

            Assert.AreEqual('q', actual1);
            Assert.AreEqual('u', actual2);
            Assert.AreEqual('p', actual3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Offset cannot be 0.")]
        public void ShouldThrowExceptionIfArgumentIsZero()
        {
            _testAlphabet.Transpose(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Offset cannot be greater than length of Alphabet.")]
        public void ShouldThrowExceptionIfArgumentIsGreaterThanAlphabetLength()
        {
            _testAlphabet.Transpose(28);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "Char not found in dictionary.")]
        public void ShouldThrowExceptionIfCharNotFoundInCharMap()
        {
            _testAlphabet.GetTransposedChar('!');
        }
    }
}
