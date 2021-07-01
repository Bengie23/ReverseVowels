using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReverseVowels;
using System;

namespace ReverseVowelsTests
{
    [TestClass]
    public class RecursiveReverseVowelsResolverTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReverseVowels_Null_String_Throws()
        {
            RecursiveReverseVowelsResolver.Resolve(null);
        }

        [TestMethod]
        [DataRow("hello", "holle")]
        [DataRow("hello, world", "hollo, werld")]
        [DataRow("codesignal", "cadisegnol")]
        [DataRow("eIaOyU", "UOaIye")]
        [DataRow(".a", ".a")]
        [DataRow("ai", "ia")]
        [DataRow("aA", "Aa")]
        [DataRow(".,", ".,")]
        [DataRow("ab", "ab")]
        [DataRow("0P", "0P")]
        [DataRow("a a", "a a")]
        [DataRow("a e", "e a")]
        [DataRow("race a car", "raca e car")]
        [DataRow("Sore was I ere I saw Eros.", "SorE was I ere I saw eros.")]
        [DataRow("A man, a plan, a canal -- Panama", "a man, a plan, a canal -- PanamA")]
        [DataRow("", "")]
        [DataRow(" ", " ")]
        public void ReverseVowels_Returns(string test,string expectedResult)
        {
            var result = RecursiveReverseVowelsResolver.Resolve(test);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
