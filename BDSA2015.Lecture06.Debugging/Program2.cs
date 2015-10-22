using BDSA2015.Lecture05.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDSA2015.Lecture06.Debugging
{
    class Program2
    {
        static void Main()
        {
            var context = new CharacterContext();

            foreach (var c in context.Characters)
            {
                Console.WriteLine(c);
            }
        }
    }
}
