using System;
using System.Threading;

namespace BDSA2015.Lecture07
{
    class Threads1
    {
        /// <summary>
        /// Run an open Process Explorer...
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello Threads");
            Console.ReadKey();
        }


        /// <summary>
        /// Run an open Process Explorer...
        /// </summary>
        /// <param name="args"></param>
        private static void Main2(string[] args)
        {
            Console.WriteLine("Hello Threads - press any key to continue...");
            Console.ReadKey();
            var t = new Thread[1000];
            for (var i = 0; i < t.Length; i++)
            {
                var number = i + 1;
                t[i] = new Thread(() =>
                {
                    Console.WriteLine("I'm thread no. {0}", number);
                    Thread.Sleep(TimeSpan.FromSeconds(10));
                });
                t[i].Start();
            }
            Console.ReadKey();
        }
    }
}
