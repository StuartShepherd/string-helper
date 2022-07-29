using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringHelper.Tests
{
    [TestClass()]
    public class StringHelperTests
    {
        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow(" ", " ")]
        [DataRow("?? ??", "?? ??")]
        [DataRow("123test", "123Test")]
        [DataRow("lorem", "Lorem")]
        [DataRow("lorem ipsum", "Lorem Ipsum")]
        public void GetCapitaliseEachWordTest(string x, string expected)
        {
            var actual = StringHelper.GetCapitaliseEachWord(x);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow("", 10, "")]
        [DataRow("Lorem ipsum dolor sit amet", 0, "")]
        [DataRow("Lorem ipsum dolor sit amet", 5, "Lorem")]
        [DataRow("Lorem ipsum dolor sit amet", 6, "Lorem ")]
        [DataRow("Lorem ipsum dolor sit amet", 11, "Lorem ipsum")]
        [DataRow("Lorem ipsum dolor sit amet", 100, "Lorem ipsum dolor sit amet")]
        public void GetLeftTest(string x, int y, string expected)
        {
            var actual = StringHelper.GetLeft(x, y);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetLeftTest_ShouldThrowArgumentOutOfRangeException()
        {
            var value = "Lorem ipsum dolor sit amet";
            var length = -1;

            var actual = StringHelper.GetLeft(value, length);
        }

        [DataTestMethod]
        [DataRow("", 10, "")]
        [DataRow("Lorem ipsum dolor sit amet", 0, "")]
        [DataRow("Lorem ipsum dolor sit amet", 6, "ipsum dolor sit amet")]
        [DataRow("Lorem ipsum dolor sit amet", 12, "dolor sit amet")]
        public void GetMid1Test(string x, int y, string expected)
        {
            var actual = StringHelper.GetMid(x, y);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetMid1Test_ShouldThrowArgumentOutOfRangeException()
        {
            var value = "Lorem ipsum dolor sit amet";
            var start = -1;

            var actual = StringHelper.GetMid(value, start);
        }

        [DataTestMethod]
        [DataRow("", 10, 10, "")]
        [DataRow("Lorem ipsum dolor sit amet", 0, 0, "")]
        [DataRow("Lorem ipsum dolor sit amet", 0, 11, "Lorem ipsum")]
        [DataRow("Lorem ipsum dolor sit amet", 6, 5, "ipsum")]
        [DataRow("Lorem ipsum dolor sit amet", 6, 100, "ipsum dolor sit amet")]
        [DataRow("Lorem ipsum dolor sit amet", 12, 9, "dolor sit")]
        [DataRow("Lorem ipsum dolor sit amet", 100, 100, "")]
        public void GetMid2Test(string x, int y, int z, string expected)
        {
            var actual = StringHelper.GetMid(x, y, z);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetMid2Test_ShouldThrowArgumentOutOfRangeException()
        {
            var value = "Lorem ipsum dolor sit amet";
            var start = -1;
            var count = -1;

            var actual = StringHelper.GetMid(value, start, count);
        }

        [DataTestMethod]
        [DataRow("", 10, "")]
        [DataRow("Lorem ipsum dolor sit amet", 0, "")]
        [DataRow("Lorem ipsum dolor sit amet", 4, "amet")]
        [DataRow("Lorem ipsum dolor sit amet", 5, " amet")]
        [DataRow("Lorem ipsum dolor sit amet", 14, "dolor sit amet")]
        [DataRow("Lorem ipsum dolor sit amet", 100, "Lorem ipsum dolor sit amet")]
        public void GetRightTest(string x, int y, string expected)
        {
            var actual = StringHelper.GetRight(x, y);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetRightTest_ShouldThrowArgumentOutOfRangeException()
        {
            var value = "Lorem ipsum dolor sit amet";
            var length = -1;

            var actual = StringHelper.GetRight(value, length);
        }

        [DataTestMethod]
        [DataRow(null, "")]
        [DataRow("Lorem ipsum", "")]
        [DataRow("Lorem 123 ipsum", "123")]
        [DataRow("Lo1rem 234 ips5um 6", "123456")]
        public void GetNumbersTest(string x, string expected)
        {
            var actual = StringHelper.GetNumbers(x);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(null, 0)]
        [DataRow("", 0)]
        [DataRow(" ", 0)]
        [DataRow("Lorem ipsum", 2)]
        [DataRow("?? ,  . ..  :: ;   ??? .", 0)]
        [DataRow("Lorem ?? , dolor sit amet. ..   ??? .", 4)]
        [DataRow("Lorem ipsum; dolor sit amet.", 5)]
        [DataRow("Lorem ipsum, dolor sit amet.", 5)]
        [DataRow("Lorem ipsum dolor sit amet", 5)]
        public void GetTotalNumberOfWordsTest(string x, int expected)
        {
            var actual = StringHelper.GetTotalNumberOfWords(x);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(null, false, 0)]
        [DataRow("Lorem", false, 5)]
        [DataRow("Lorem ipsum", false, 11)]
        [DataRow("Lorem ipsum", true, 11)]
        [DataRow("Lorem \nipsum", true, 11)]
        [DataRow("Lorem         ipsum   dolor", true, 17)]
        public void GetTotalNumberOfCharactersTest(string x, bool y, int expected)
        {
            var actual = StringHelper.GetTotalNumberOfCharacters(x, y);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow(" ", "")]
        [DataRow("Lorem \nipsum", "Lorem ipsum")]
        [DataRow("Lorem \nipsum dolor \nsit amet", "Lorem ipsum dolor sit amet")]
        [DataRow(" Lorem       \tipsum         ", "Lorem ipsum")]
        public void GetCleanStringTest(string x, string expected)
        {
            var actual = StringHelper.GetCleanString(x);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(null, null, 0)]
        [DataRow("Lorem ipsum", "dolor", 0)]
        [DataRow("Lorem ipsum", "ipsum", 1)]
        [DataRow("Lorem ipsum dolor sit amet lorem ipsum dolor lorem", "dolor", 2)]
        [DataRow("Lorem ipsum dolor sit amet lorem ipsum dolor lorem", "lorem", 2)]
        [DataRow("Lorem ipsum dolor sit amet lorem ipsum dolor lorem", "re", 3)]
        [DataRow("Lorem ipsum dolor sit amet lorem ipsum dolor lorem", " ", 8)]
        public void GetStringCountTest(string x, string y, int expected)
        {
            var actual = StringHelper.GetStringCount(x, y);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow("", "")]
        [DataRow(" ", "")]
        [DataRow("Lorem ipsum", "Lorem ipsum")]
        [DataRow("Lorem  ipsum", "Lorem ipsum")]
        [DataRow("Lorem  ipsum ", "Lorem ipsum")]
        [DataRow(" Lorem       ipsum         ", "Lorem ipsum")]
        public void RemoveExtraSpacesTest(string x, string expected)
        {
            var actual = StringHelper.RemoveExtraSpaces(x);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow("", "")]
        [DataRow(" ", " ")]
        [DataRow("Test", "Test")]
        [DataRow("\"Test\"", "'Test'")]
        [DataRow("Lorem \"ipsum", "Lorem 'ipsum")]
        public void ReplaceDoubleQuotesWithSingleTest(string x, string expected)
        {
            var actual = StringHelper.ReplaceDoubleQuotesWithSingle(x);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow(" ", " ")]
        [DataRow("Test", "Test")]
        [DataRow("'Test'", "\"Test\"")]
        [DataRow("Lorem 'ipsum", "Lorem \"ipsum")]
        public void ReplaceSingleQuotesWithDoubleTest(string x, string expected)
        {
            var actual = StringHelper.ReplaceSingleQuotesWithDouble(x);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow(" ", "")]
        [DataRow("Lorem \nipsum", "Lorem ipsum")]
        [DataRow("Lorem \nipsum dolor \nsit amet", "Lorem ipsum dolor sit amet")]
        public void ReplaceNewLinesWithSpacesTest(string x, string expected)
        {
            var actual = StringHelper.ReplaceNewLinesWithSpaces(x);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow(" ", "")]
        [DataRow("Lorem \tipsum", "Lorem ipsum")]
        [DataRow("Lorem \tipsum dolor \tsit amet", "Lorem ipsum dolor sit amet")]
        public void ReplaceTabsWithSpacesTest(string x, string expected)
        {
            var actual = StringHelper.ReplaceTabsWithSpaces(x);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow(" ", " ")]
        [DataRow("Lorem ipsum", "muspi meroL")]
        [DataRow("A12345", "54321A")]
        public void ReverseTest(string x, string expected)
        {
            var actual = StringHelper.Reverse(x);
            Assert.AreEqual(expected, actual);
        }
    }
}
