using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;

namespace BDSA2015.Lecture01.StartApp.Tests
{
    [TestClass]
    public class ProgramTests
    {
        private StringWriter _writer;

        public string WriterValue()
        {
            return _writer.GetStringBuilder().ToString().TrimEnd();
        }

        [TestInitialize]
        public void Initialize()
        {
            _writer = new StringWriter();
            Console.SetOut(_writer);
        }

        [TestMethod]
        public void Main_When_Run_Prints_Hello_World()
        {
            // Arrange

            // Act
            Program.Main(null);

            // Assert
            Assert.AreEqual("Hello, World!", WriterValue());
        }

        [TestMethod]
        public void Main_When_Run_With_Name_Prints_Hello_Name()
        {
            // Arrange
            string[] args = { "Rasmus" };

            // Act
            Program.Main(args);

            // Assert
            Assert.AreEqual("Hello, Rasmus!", WriterValue());
        }
    }
}
