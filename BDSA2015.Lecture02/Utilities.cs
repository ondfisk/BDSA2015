using System;
using System.Collections.Generic;

namespace BDSA2015.Lecture02
{
    public class Utilities
    {
        public static IList<int> GetEven(ICollection<int> list)
        {
            var evens = new List<int>();

            foreach (var item in list)
            {
                if (item % 2 == 0)
                {
                    evens.Add(item);
                }
            }

            return evens;
        }

        public static bool Find(int[] list, int number)
        {
            for (int index = 0; index < list.Length; index++)
            {
                var item = list[index];

                if (item == number)
                {
                    return true;
                }
            }
            return false;
        }

        public static ISet<int> Unique(List<int> numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            var set = new HashSet<int>();

            foreach (var number in numbers)
            {
                set.Add(number);
            }

            return set;
        }

        public static List<Duck> Sort(List<Duck> ducks, IComparer<Duck> comparer)
        {
            ducks.Sort(comparer);

            return ducks;
        }

        public static IDictionary<int, Duck> ConvertToDictionary(IEnumerable<Duck> people)
        {
            var dict = new Dictionary<int, Duck>();

            throw new NotImplementedException();
        }

        public static IEnumerable<Duck> GetOlder(IEnumerable<Duck> ducks, int olderThan)
        {
            foreach (var duck in ducks)
            {
                if (duck.Age > olderThan)
                {
                    yield return duck;
                }
            }
        }
    }
}
