using System;
using System.Data.Entity.Migrations;
using System.IO;
using System.Reflection;
using System.Web;

namespace BDSA2015.Lecture10.Entities.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<CharacterContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CharacterContext context)
        {
            context.Publishers.AddOrUpdate(h => h.Id,
                new Publisher { Id = 1, Name = "DC Comics" },
                new Publisher { Id = 2, Name = "Marvel Comics" },
                new Publisher { Id = 3, Name = "The Walt Disney Company" }
            );

            context.Characters.AddOrUpdate(h => h.Id,
                new Character { Id = 1, PublisherId = 1, GivenName = "Clark", Surname = "Kent", AlterEgo = "Superman", Image = GetImage("Superman.png") },
                new Character { Id = 2, PublisherId = 1, GivenName = "Bruce", Surname = "Wayne", AlterEgo = "Batman", Image = GetImage("Batman.png") },
                new Character { Id = 3, PublisherId = 2, GivenName = "Tony", Surname = "Stark", AlterEgo = "Iron Man", Image = GetImage("IronMan.png") },
                new Character { Id = 4, PublisherId = 2, GivenName = "James", Surname = "Howlett", AlterEgo = "Wolverine", Image = GetImage("Wolverine.png") },
                new Character { Id = 5, PublisherId = 3, GivenName = "Donald", Surname = "Duck", AlterEgo = "The Duck Avenger", Image = GetImage("TheDuckAvenger.png") },
                new Character { Id = 6, PublisherId = 3, GivenName = "Daisy", Surname = "Duck", AlterEgo = "Super Daisy", Image = GetImage("SuperDaisy.png") },
                new Character { Id = 7, PublisherId = 3, GivenName = "Goofy", AlterEgo = "Super Goof", Image = GetImage("SuperGoof.png") }
            );
        }

        private byte[] GetImage(string fileName)
        {
            var path = GetPath(fileName);

            using (var file = File.OpenRead(path))
            using (var memory = new MemoryStream())
            {
                file.CopyTo(memory);
                return memory.ToArray();
            }
        }

        private string GetPath(string fileName)
        {
            var url = new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath;

            var folder = HttpUtility.UrlDecode(url).Replace("/", "\\");

            var path = Path.Combine(folder, "..", "..", "..", "Images", fileName);

            return path;
        }
    }
}
