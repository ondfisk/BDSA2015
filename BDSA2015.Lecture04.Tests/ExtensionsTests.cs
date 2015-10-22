using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BDSA2015.Lecture04.Tests
{
    [TestClass]
    public class ExtensionsTests
    {
        [TestMethod]
        public void Evens()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            var evens = numbers.Evens();

            int[] expected = { 2, 4 };

            CollectionAssert.AreEqual(expected.ToList(), evens.ToList());
        }

        [TestMethod]
        public void Evens_Up_To()
        {

        }
    }
}
