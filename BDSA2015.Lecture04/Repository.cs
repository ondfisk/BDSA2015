using System;
using System.Collections.Generic;

namespace BDSA2015.Lecture04
{
    public class Repository
    {
        public IList<Superhero> Superheroes { get; }

        public IList<Locality> Localities { get; }

        public Repository()
        {
            Localities = new List<Locality> 
            {
                new Locality { Id = 1, Name = "New York" },
                new Locality { Id = 2, Name = "Metropolis" },
                new Locality { Id = 3, Name = "Gotham City" },
                new Locality { Id = 4, Name = "Dayton" },
                new Locality { Id = 5, Name = "Alberta" }
            };

            Superheroes = new List<Superhero> 
            {
                new Superhero {Id = 1, GivenName = "Clark", Surname = "Kent", AlterEgo = "Superman", Gender = Gender.Male, FirstAppearance = DateTime.Parse("1938-04-18"), LocalityId = 2 },
                new Superhero {Id = 2, GivenName = "Bruce", Surname = "Wayne", AlterEgo = "Batman", Gender = Gender.Male, FirstAppearance = DateTime.Parse("1939-05-01"), LocalityId = 3 },
                new Superhero {Id = 3, GivenName = "Wonder Woman", AlterEgo = "Princess Diana of Themyscira", Gender = Gender.Female, FirstAppearance = DateTime.Parse("1941-12-01") },
                new Superhero {Id = 4, GivenName = "Bruce", Surname = "Banner", AlterEgo = "Hulk", Gender = Gender.Male, FirstAppearance = DateTime.Parse("1962-05-01"), LocalityId = 4 },
                new Superhero {Id = 5, GivenName = "Steve", Surname = "Rogers", AlterEgo = "Captain America", Gender = Gender.Male, FirstAppearance = DateTime.Parse("1941-03-01"), LocalityId = 1 },
                new Superhero {Id = 6, GivenName = "Tony", Surname = "Stark", AlterEgo = "Iron Man", Gender = Gender.Male, FirstAppearance = DateTime.Parse("1963-03-01"), LocalityId = 1 },
                new Superhero {Id = 7, GivenName = "James", Surname = "Howlett", AlterEgo = "Wolverine", Gender = Gender.Male, FirstAppearance = DateTime.Parse("1974-10-01"), LocalityId = 5 },
                new Superhero {Id = 8, GivenName = "Selina", Surname = "Kyle", AlterEgo = "Catwoman", Gender = Gender.Female, FirstAppearance = DateTime.Parse("1940-04-01"), LocalityId = 3 },
            };
        }
    }
}
