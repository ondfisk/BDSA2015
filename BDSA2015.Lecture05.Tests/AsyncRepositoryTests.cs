using System.Collections.Generic;
using BDSA2015.Lecture05.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BDSA2015.Lecture05.Tests
{
    [TestClass]
    public class AsyncRepositoryTests
    {
        private IList<Character> _data;
        private Mock<ICharacterContext> _context;
        private Mock<DbSet<Character>> _set;
        private AsyncRepository _repository;

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
            context.Setup(s => s.SaveChanges()).Returns(() =>
            {
                var max = _data.Max(c => c.Id);
                foreach (var character in _data.Where(c => c.Id == 0))
                {
                    character.Id = ++max;
                }
                return 0;
            });
            context.Setup(s => s.SaveChangesAsync()).Returns(async () =>
            {
                var max = _data.Max(c => c.Id);
                foreach (var character in _data.Where(c => c.Id == 0))
                {
                    character.Id = ++max;
                }
                return await Task.FromResult(0);
            });

            _context = context;
            _repository = new AsyncRepository(_context.Object);
        }

        [TestMethod]
        public async Task Create_Calls_SaveChangesAsync()
        {
            var character = new CharacterDto();

            await _repository.Create(character);

            _context.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [TestMethod]
        public async Task Create_Adds_New_Character_Maps_Properties()
        {
            var character = new CharacterDto { GivenName = "Steve", Surname = "Rogers", AlterEgo = "Captain America" };

            var id = await _repository.Create(character);

            var inserted = _data.First(f => f.Id == id);
            Assert.AreEqual("Steve", inserted.GivenName);
            Assert.AreEqual("Rogers", inserted.Surname);
            Assert.AreEqual("Captain America", inserted.AlterEgo);
        }

        [TestMethod]
        public async Task Create_Returns_new_Id()
        {
            var character = new CharacterDto { GivenName = "Steve", Surname = "Rogers", AlterEgo = "Captain America" };

            var id = await _repository.Create(character);

            Assert.AreEqual(9, id);
        }

        [TestMethod]
        public async Task Update_Calls_SaveChangesAsync()
        {
            var character = new CharacterDto { Id = 1 };

            await _repository.Update(character);

            _context.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [TestMethod]
        public async Task Update_Updates_GivenName()
        {
            var character = new CharacterDto { Id = 1, GivenName = "C." };

            await _repository.Update(character);

            var superman = _data[0];

            Assert.AreEqual("C.", superman.GivenName);
        }

        [TestMethod]
        public async Task Update_Updates_Surname()
        {
            var character = new CharacterDto { Id = 1, Surname = "K." };

            await _repository.Update(character);

            var superman = _data[0];

            Assert.AreEqual("K.", superman.Surname);
        }

        [TestMethod]
        public async Task Update_Updates_AlterEgo()
        {
            var character = new CharacterDto { Id = 1, AlterEgo = "The Man of Steel" };

            await _repository.Update(character);

            var superman = _data[0];

            Assert.AreEqual("The Man of Steel", superman.AlterEgo);
        }

        [TestMethod]
        public async Task Delete_Removes_Character()
        {
            await _repository.Delete(1);

            Assert.IsFalse(_data.Any(a => a.Id == 1));
        }

        [TestMethod]
        public async Task Delete_Calls_SaveChangesAsync()
        {
            await _repository.Delete(1);

            _context.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [TestMethod]
        public async Task ReadById()
        {
            var no2 = await _repository.Read(2);

            Assert.AreEqual("Batman", no2.AlterEgo);
        }
    }
}
