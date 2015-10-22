using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDSA2015.Lecture04
{
    public static class Extensions
    {
        public static void Print<T>(this IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        public static IEnumerable<int> Evens(this IEnumerable<int> numbers)
        {
            foreach (var number in numbers)
            {
                if (number % 2 == 0)
                {
                    yield return number;
                }
            }
        }

        public static bool Evens<T>(this T item, Func<T, int> predicate)
        {
            if (predicate(item) % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static IEnumerable<int> EvensUpTo(this IEnumerable<int> numbers, int stop)
        {
            foreach (var number in numbers)
            {
                if (number >= stop)
                {
                    yield break;
                }

                if (number % 2 == 0)
                {
                    yield return number;
                }
            }
        }
    }
}
