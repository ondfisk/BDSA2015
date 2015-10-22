using System;
using System.Collections;
using System.Collections.Generic;

namespace BDSA2015.Lecture02
{
    public class ForeverCounterTyped<T> : IEnumerable<T> where T : struct, IEquatable<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            Console.WriteLine("GetEnumerator...");
            return new Enumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class Enumerator : IEnumerator<T>
        {
            private T _current;

            public void Dispose()
            {
                Console.WriteLine("Dispose...");
            }

            public bool MoveNext()
            {
                Console.WriteLine("MoveNext...");
                Current = (Current as dynamic) + 1;
                return true;
            }

            public void Reset()
            {
                Console.WriteLine("Reset...");
                Current = default(T);
            }

            public T Current
            {
                get
                {
                    Console.WriteLine("Get Current...");
                    return _current;
                }
                private set
                {
                    Console.WriteLine("Set Current...");
                    _current = value;
                }
            }

            object IEnumerator.Current => Current;
        }
    }
}
