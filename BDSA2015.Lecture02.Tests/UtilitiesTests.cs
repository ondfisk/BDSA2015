using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BDSA2015.Lecture02.Tests
{
    [TestClass]
    public class UtilitiesTests
    {
        [TestMethod]
        public void GetEven_Test1()
        {
            var list = new[] { 1, 2, 3, 4 };

            var evens = Utilities.GetEven(list);

            var expected = new[] { 2, 4 };

            CollectionAssert.AreEqual(expected, evens as ICollection);
        }

        [TestMethod]
        public void Find_Not_Found_Returns_False()
        {
            var list = new[] { 1, 2, 3 };

            var result = Utilities.Find(list, 0);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Find_Found_Returns_True()
        {
            var list = new[] { 1, 2, 3 };

            var result = Utilities.Find(list, 2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Unique_Given_Empty_List_Returns_Empty_Set()
        {
            var list = new List<int>();

            var result = Utilities.Unique(list);

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Unique_Given_null_throws_ArgumentNullException()
        {
            var result = Utilities.Unique(null);
        }

        [TestMethod]
        public void Unique_Returns_Unique()
        {
            var list = new List<int> { 1, 1, 2, 3, 4, 5, 5 };

            var result = Utilities.Unique(list);

            var expected = new List<int> { 1, 2, 3, 4, 5 };

            CollectionAssert.AreEqual(expected, result.ToList());
        }

        [TestMethod]
        public void DuckSorter()
        {
            var ducks = new List<Duck> {
                        new Duck { Id = 1, Name = "Donald Duck", Age = 32 },
                        new Duck { Id = 2, Name = "Daisy Duck", Age = 30 },
                        new Duck { Id = 3, Name = "Huey Duck", Age = 10 }
                    };

            var result = Utilities.Sort(ducks, new DuckAgeComparer());

            var expected = new List<Duck> {
                        new Duck { Id = 3, Name = "Huey Duck", Age = 10 },
                        new Duck { Id = 2, Name = "Daisy Duck", Age = 30 },
                        new Duck { Id = 1, Name = "Donald Duck", Age = 32 }
            };

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetOlder()
        {
            var ducks = new List<Duck> {
                new Duck { Id = 1, Name = "Donald Duck", Age = 32 },
                new Duck { Id = 2, Name = "Daisy Duck", Age = 30 },
                new Duck { Id = 3, Name = "Huey Duck", Age = 10 }
            };

            var older = Utilities.GetOlder(ducks, 29);

            var expected = new List<Duck> {
                new Duck { Id = 2, Name = "Daisy Duck", Age = 30 },
                new Duck { Id = 1, Name = "Donald Duck", Age = 32 }
            };

            // AreEquivalent compares to collections but disregards the internal order
            CollectionAssert.AreEquivalent(expected, older.ToList());
        }
    }
}
