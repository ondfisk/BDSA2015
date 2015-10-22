using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BDSA2015.Lecture01.BankLibrary.Tests
{
    [TestClass]
    public class BankTests
    {
        [TestMethod]
        public void Bank_When_Constructed_Hold_Zero_Balance()
        {
            // Arrange
            var bank = new Bank();

            // Act
            var actual = bank.Balance;

            // Assert
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void Bank_When_Constructed_With_Balance_Hold_That_Balance()
        {
            // Arrange
            int expected = 42;
            var bank = new Bank(expected);

            // Act
            var actual = bank.Balance;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Deposit_Increases_Balance_With_Value()
        {
            // Arrange
            var bank = new Bank();

            // Act
            bank.Deposit(42);

            var actual = bank.Balance;

            // Assert
            Assert.AreEqual(42, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void Deposit_Balance_1_IntMaxValue_Overflow()
        {
            // Arrange
            var bank = new Bank(1);

            // Act
            bank.Deposit(int.MaxValue);

            var actual = bank.Balance;

            // Assert
        }
    }
}
