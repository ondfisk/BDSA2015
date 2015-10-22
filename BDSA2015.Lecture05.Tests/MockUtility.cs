using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Moq;
using System.Reflection;
using System.Linq.Expressions;

namespace BDSA2015.Lecture05.Tests
{
    public static class MockUtility
    {
        public static Mock<DbSet<T>> CreateMockDbSet<T>(ICollection<T> items, Func<T, int> key) where T : class
        {
            var data = items.AsQueryable();
            var set = new Mock<DbSet<T>>();
            set.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.Provider);
            set.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
            set.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
            set.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            set.Setup(m => m.Find(It.IsAny<object[]>())).Returns<object[]>(ids => items.FirstOrDefault(d => key(d) == (int)ids[0]));

            set.Setup(m => m.Add(It.IsAny<T>())).Callback<T>(a => items.Add(a));
            set.Setup(m => m.Remove(It.IsAny<T>())).Callback<T>(a => items.Remove(a));

            return set;
        }

        public static string GetConcatanted(string start, params string[] strings)
        {
            
            return null;
        }
        public static string Stuff(string start = "dfd", string end = null, int stuff = 42, DateTime? time = null)
        {
            return null;
        }

        public static void Func()
        {
            Stuff(end: "end");

            GetConcatanted("foo");
            GetConcatanted("start");
            GetConcatanted(null);
            GetConcatanted("foo", "bar", "foo1");
            GetConcatanted("start", new[] { "foo", "bar", "foo1" });
        }
    }
}
