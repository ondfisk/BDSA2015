using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BDSA2015.Lecture02.Tests
{
    [TestClass]
    public class RegexTests
    {
        private readonly string postalCodePattern = @"^\d{4}$";
        private readonly string postalCodeGroupPattern = @"(\b\d{4}\b)";

        [TestMethod]
        public void Danish_Postal_Code_Good_One()
        {
            var postalCode = "2100";

            var result = RegexTester.IsMatch(postalCode, postalCodePattern);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Danish_Postal_Code_Too_Short()
        {
            var postalCode = "210";

            var result = RegexTester.IsMatch(postalCode, postalCodePattern);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Danish_Postal_Code_Too_Long()
        {
            var postalCode = "21000";

            var result = RegexTester.IsMatch(postalCode, postalCodePattern);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Danish_Postal_Code_Dunno()
        {
            var postalCode = " 2100 København Ø ";

            var result = RegexTester.IsMatch(postalCode, postalCodePattern);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Danish_Postal_Code_Capture_By_Group()
        {
            var postalCode = " 2100 København Ø ";

            var result = RegexTester.Groups(postalCode, postalCodeGroupPattern);

            var code = result[0];

            Assert.AreEqual("2100", code);
        }

        [TestMethod]
        public void Danish_Postal_Code_But_Swedish()
        {
            var postalCode = " l5555 Malmø ";

            var result = RegexTester.Groups(postalCode, postalCodeGroupPattern);

            Assert.AreEqual(0, result.Count);
        }
    }
}
