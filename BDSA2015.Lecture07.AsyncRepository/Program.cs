using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using BDSA2015.Lecture05.Entities;

namespace BDSA2015.Lecture07.AsyncRepository
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Bruce().Result);
        }

        static async Task<CharacterDto> Bruce()
        {
            using (var context = new CharacterContext())
            using (var repository = new EntityRepository(context))
            {
                var ch = from c in repository.Get()
                         where c.GivenName == "Bruce"
                         select c;

                var bruce = await ch.FirstOrDefaultAsync();

                return bruce;
            }
        }
    }
}
