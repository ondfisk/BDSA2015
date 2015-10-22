using System.Collections;
using System.Collections.Generic;

namespace BDSA2015.Lecture02
{
    public class ForeverCounter : IEnumerable<byte>
    {
        public IEnumerator<byte> GetEnumerator()
        {
            return new Enumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class Enumerator : IEnumerator<byte>
        {
            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                Current++;
                return true;
            }

            public void Reset()
            {
                Current = default(byte);
            }

            public byte Current { get; private set; }

            object IEnumerator.Current => Current;
        }

        #region Static
        public static IEnumerable<long> Static()
        {
            var counter = default(long);

            while (true)
            {
                counter++;

                yield return counter;
            }
        }
        #endregion
    }
}
