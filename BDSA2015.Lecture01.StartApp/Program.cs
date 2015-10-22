using System;

namespace BDSA2015.Lecture01.StartApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string name;

            if (args == null || args.Length == 0)
            {
                name = "World";
            }
            else
            {
                name = args[0];
            }

            Console.WriteLine($"Hello, {name}!");
        }
    }
}
