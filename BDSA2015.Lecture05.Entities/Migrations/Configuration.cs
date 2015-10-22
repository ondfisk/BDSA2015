using System.Data.Entity.Migrations;

namespace BDSA2015.Lecture05.Entities.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<CharacterContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CharacterContext context)
        {
            context.Characters.AddOrUpdate(h => h.Id,
                new Character { Id = 1, GivenName = "Clark", Surname = "Kent", AlterEgo = "Superman" },
                new Character { Id = 2, GivenName = "Bruce", Surname = "Wayne", AlterEgo = "Batman" },
                new Character { Id = 3, GivenName = "Wonder Woman", AlterEgo = "Princess Diana of Themyscira" },
                new Character { Id = 4, GivenName = "Bruce", Surname = "Banner", AlterEgo = "Hulk" },
                new Character { Id = 5, GivenName = "Steve", Surname = "Rogers", AlterEgo = "Captain America" },
                new Character { Id = 6, GivenName = "Tony", Surname = "Stark", AlterEgo = "Iron Man" },
                new Character { Id = 7, GivenName = "James", Surname = "Howlett", AlterEgo = "Wolverine" },
                new Character { Id = 8, GivenName = "Selina", Surname = "Kyle", AlterEgo = "Catwoman" }
            );
        }
    }
}
