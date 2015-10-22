using BDSA2015.Lecture05.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDSA2015.Lecture05.Tests
{
    [TestClass]
    public class MapperTests
    {
        [TestMethod]
        public void Map_Character_to_CharacterDTO_GivenName()
        {
            var character = new Character { FirstName = "Bruce" };

            var mapper = new Mapper();

            var dto = mapper.Map(character);

            Assert.AreEqual("Bruce", dto.GivenName);
        }
    }
}
