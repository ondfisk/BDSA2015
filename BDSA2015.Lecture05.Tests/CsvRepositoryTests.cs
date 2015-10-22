using BDSA2015.Lecture05.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BDSA2015.Lecture05.Tests
{
    [TestClass]
    public class CsvRepositoryTests
    {
        [TestMethod]
        public void Post_calls_Save_once()
        {
            var crud = new Mock<CrudAdapter>();

            using (var repository = new CsvRepository(crud.Object, new Mapper()))
            {
                var dto = new CharacterDto();

                var id = repository.Post(dto);

                crud.Verify(c => c.Create(It.IsAny<Character>()), Times.Once);
            }
        }

        [TestMethod]
        public void Post_Save_new_Character()
        {
            var crud = new Mock<CrudAdapter>();
            var mapper = new Mock<Mapper>();
            var repository = new CsvRepository(crud.Object, mapper.Object);

            var ch = new Character();

            mapper.Setup(m => m.Map(It.IsAny<CharacterDto>())).Returns(ch);

            repository.Post(new CharacterDto());

            crud.Verify(c => c.Create(ch), Times.Once);
        }
    }
}
