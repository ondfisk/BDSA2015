using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace BDSA2015.Lecture04
{
    class Program
    {
        private static void Main(string[] args)
        {
            using (var ctx = new HeroContext())
            {
                var ws = from h in ctx.Superheroes
                         where h.Locality.Name == "Gotham City"
                         select new { h.AlterEgo, Locality = h.Locality.Name };

                Console.WriteLine(ws.Count());
            }
        }

        private static void Hamlet(string[] args)
        {
            using (var file = File.OpenText("Hamlet.txt"))
            {
                var text = file.ReadToEnd();

                var words = Regex.Split(text, @"\P{L}+");

                var histo = from w in words
                            let normalized = w.ToLower()
                            group w by normalized into g
                            orderby g.Count() descending
                            select new { Word = g.Key, Count = g.Count() };

                var dict = histo.ToLookup(d => d.Count);

                var wordsFiveTimes = dict[5];

                wordsFiveTimes.Print();
            }

        }
    }
}
