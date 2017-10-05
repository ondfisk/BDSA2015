using System.Collections.Generic;

namespace BDSA2015.Lecture11.App
{
    public class Duck
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public static IReadOnlyList<Duck> All =>
            new List<Duck>
            {
                new Duck { Id = 1, Name = "Donald Duck" },
                new Duck { Id = 2, Name = "Daisy Duck" },
                new Duck { Id = 3, Name = "Scrooge McDuck" },
                new Duck { Id = 4, Name = "Grandma Duck" },
                new Duck { Id = 5, Name = "Fethry Duck" },
                new Duck { Id = 6, Name = "Huey Duck" },
                new Duck { Id = 7, Name = "Dewey Duck" },
                new Duck { Id = 8, Name = "Louie Duck" },
                new Duck { Id = 9, Name = "Gladstone Gander" },
                new Duck { Id = 10, Name =  "Ludwig Von Drake" },
            };
    }
}
