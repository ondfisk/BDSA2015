using System;
using System.Linq;

namespace BDSA2015.Lecture11.App
{
    public class Delegates
    {
        public delegate void Act<in T>(T obj);

        public delegate TResult Fun<in T, out TResult>(T arg);

        public IOrderedEnumerable<Duck> Sort()
        {
            Func<Duck, string> name = delegate (Duck duck)
                                      {
                                          return duck.Name;
                                      };

            Func<Duck, string> name2 = d => d.Name;


            var filter = Duck.All.Where(delegate (Duck d) { return d.Id == 2; });

            var filter2 = Duck.All.Where(d => d.Id == 2);

            return Duck.All.OrderBy(d => d.Name);
        }
    }
}
