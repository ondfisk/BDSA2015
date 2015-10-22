using System.Collections.Generic;
using BDSA2015.Lecture05.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;
using System.Linq;

namespace BDSA2015.Lecture05.Tests
{
    [TestClass]
    public class EntityRepositoryTests
    {
        private IList<Character> _data;
        private Mock<ICharacterContext> _context;
        private Mock<DbSet<Character>> _set;
        private EntityRepository _repository;

        [TestInitialize]
        public void Initialize()
        {
            _data = new List<Character>
            {
                new Character {Id = 1, GivenName = "Clark", Surname = "Kent", AlterEgo = "Superman"},
                new Character {Id = 2, GivenName = "Bruce", Surname = "Wayne", AlterEgo = "Batman"},
                new Character {Id = 3, GivenName = "Wonder Woman", AlterEgo = "Princess Diana of Themyscira"},
                new Character {Id = 4, GivenName = "Bruce", Surname = "Banner", AlterEgo = "Hulk"},
                new Character {Id = 5, GivenName = "Steve", Surname = "Rogers", AlterEgo = "Captain America"},
                new Character {Id = 6, GivenName = "Tony", Surname = "Stark", AlterEgo = "Iron Man"},
                new Character {Id = 7, GivenName = "James", Surname = "Howlett", AlterEgo = "Wolverine"},
                new Character {Id = 8, GivenName = "Selina", Surname = "Kyle", AlterEgo = "Catwoman"}
            };
            _set = MockUtility.CreateMockDbSet(_data, c => c.Id);
            var context = new Mock<ICharacterContext>();
            context.Setup(s => s.Characters).Returns(_set.Object);
            context.Setup(s => s.SaveChanges()).Callback(() =>
            {
                var max = _data.Max(c => c.Id);
                foreach (var character in _data.Where(c => c.Id == 0))
                {
                    character.Id = ++max;
                }
            });

            _context = context;
            _repository = new EntityRepository(_context.Object);
        }

        [TestMethod]
        public void Post_Calls_Save_Changes()
        {
            var character = new CharacterDto();

            _repository.Post(character);

            _context.Verify(r => r.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void Post_Adds_New_Character_Maps_Properties()
        {
            var character = new CharacterDto { GivenName = "Steve", Surname = "Rogers", AlterEgo = "Captain America" };

            _repository.Post(character);

            var inserted = _data.First(f => f.Id == 0);
            Assert.AreEqual("Steve", inserted.GivenName);
            Assert.AreEqual("Rogers", inserted.Surname);
            Assert.AreEqual("Captain America", inserted.AlterEgo);
        }

        [TestMethod]
        public void Post_Returns_new_Id()
        {
            var character = new CharacterDto { GivenName = "Steve", Surname = "Rogers", AlterEgo = "Captain America" };

            var id = _repository.Post(character);

            Assert.AreEqual(9, id);
        }

        [TestMethod]
        public void Put_Calls_Save_Changes()
        {
            var character = new CharacterDto { Id = 1 };

            _repository.Put(character);

            _context.Verify(r => r.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void Put_Updates_GivenName()
        {
            var character = new CharacterDto { Id = 1, GivenName = "C." };

            _repository.Put(character);

            var superman = _data[0];

            Assert.AreEqual("C.", superman.GivenName);
        }

        [TestMethod]
        public void Put_Updates_Surname()
        {
            var character = new CharacterDto { Id = 1, Surname = "K." };

            _repository.Put(character);

            var superman = _data[0];

            Assert.AreEqual("K.", superman.Surname);
        }

        [TestMethod]
        public void Put_Updates_AlterEgo()
        {
            var character = new CharacterDto { Id = 1, AlterEgo = "The Man of Steel" };

            _repository.Put(character);

            var superman = _data[0];

            Assert.AreEqual("The Man of Steel", superman.AlterEgo);
        }

        [TestMethod]
        public void Delete_Removes_Character()
        {
            _repository.Delete(1);

            Assert.IsFalse(_data.Any(a => a.Id == 1));
        }

        [TestMethod]
        public void Delete_Calls_Save_Changes()
        {
            _repository.Delete(1);

            _context.Verify(r => r.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void GetById()
        {
            var no2 = _repository.Get(2);

            Assert.AreEqual("Batman", no2.AlterEgo);
        }

        [TestMethod]
        public void GetByAlterEgo()
        {
            using (var repository = new EntityRepository(_context.Object))
            {
                var iron = repository.Get('I').ToList();

                Assert.AreEqual("Iron Man", iron[0].AlterEgo);
            }
        }
    }
}
