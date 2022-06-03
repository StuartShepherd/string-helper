using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringHelper.Tests
{
    [TestClass()]
    public class StringHelperTests
    {
        [DataTestMethod]
        [DataRow("", 10, "")]
        [DataRow("Lorem ipsum dolor sit amet", 0, "")]
        [DataRow("Lorem ipsum dolor sit amet", 5, "Lorem")]
        [DataRow("Lorem ipsum dolor sit amet", 6, "Lorem ")]
        [DataRow("Lorem ipsum dolor sit amet", 11, "Lorem ipsum")]
        [DataRow("Lorem ipsum dolor sit amet", 100, "Lorem ipsum dolor sit amet")]
        public void LeftTest(string x, int y, string expected)
        {
            var actual = StringHelper.Left(x, y);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void LeftTest_ShouldThrowArgumentOutOfRangeException()
        {
            var value = "Lorem ipsum dolor sit amet";
            var length = -1;

            var actual = StringHelper.Left(value, length);
        }

        [DataTestMethod]
        [DataRow("", 10, "")]
        [DataRow("Lorem ipsum dolor sit amet", 0, "")]
        [DataRow("Lorem ipsum dolor sit amet", 4, "amet")]
        [DataRow("Lorem ipsum dolor sit amet", 5, " amet")]
        [DataRow("Lorem ipsum dolor sit amet", 14, "dolor sit amet")]
        [DataRow("Lorem ipsum dolor sit amet", 100, "Lorem ipsum dolor sit amet")]
        public void RightTest(string x, int y, string expected)
        {
            var actual = StringHelper.Right(x, y);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RightTest_ShouldThrowArgumentOutOfRangeException()
        {
            var value = "Lorem ipsum dolor sit amet";
            var length = -1;

            var actual = StringHelper.Right(value, length);
        }

        [DataTestMethod]
        [DataRow("", 10, "")]
        [DataRow("Lorem ipsum dolor sit amet", 0, "")]
        [DataRow("Lorem ipsum dolor sit amet", 6, "ipsum dolor sit amet")]
        [DataRow("Lorem ipsum dolor sit amet", 12, "dolor sit amet")]
        public void Mid1Test(string x, int y, string expected)
        {
            var actual = StringHelper.Mid(x, y);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Mid1Test_ShouldThrowArgumentOutOfRangeException()
        {
            var value = "Lorem ipsum dolor sit amet";
            var start = -1;

            var actual = StringHelper.Mid(value, start);
        }

        [DataTestMethod]
        [DataRow("", 10, 10, "")]
        [DataRow("Lorem ipsum dolor sit amet", 0, 0, "")]
        [DataRow("Lorem ipsum dolor sit amet", 0, 11, "Lorem ipsum")]
        [DataRow("Lorem ipsum dolor sit amet", 6, 5, "ipsum")]
        [DataRow("Lorem ipsum dolor sit amet", 6, 100, "ipsum dolor sit amet")]
        [DataRow("Lorem ipsum dolor sit amet", 12, 9, "dolor sit")]
        [DataRow("Lorem ipsum dolor sit amet", 100, 100, "")]
        public void Mid2Test(string x, int y, int z, string expected)
        {
            var actual = StringHelper.Mid(x, y, z);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Mid2Test_ShouldThrowArgumentOutOfRangeException()
        {
            var value = "Lorem ipsum dolor sit amet";
            var start = -1;
            var count = -1;

            var actual = StringHelper.Mid(value, start, count);
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
        public void WordCountTest(string x, int expected)
        {
            var actual = StringHelper.WordCount(x);
            Assert.AreEqual(expected, actual);
        }
    }
}
