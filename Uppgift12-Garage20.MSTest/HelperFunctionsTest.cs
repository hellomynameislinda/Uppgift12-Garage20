using Uppgift12_Garage20.Helpers;

namespace Uppgift12_Garage20.MSTest
{
    [TestClass]
    public class HelperFunctionsTest
    {
        [TestMethod]
        public void ParkedTimeAmount_ShouldReturn_Ninetyfiveminutes()
        {
            // Arrange
            DateTime arrivalTime = new DateTime(2024, 04, 17, 12, 0, 0);
            DateTime departureTime = new DateTime(2024, 04, 17, 13, 35, 0);

            TimeSpan expected = new TimeSpan(1, 35, 0);

            // Act
            var actual = HelperFunctions.ParkedTimeAmount(arrivalTime, departureTime);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ParkedTimeAmount_ShouldReturn_Exception()
        {
            // Arrange
            DateTime arrivalTime = new DateTime(2024, 04, 17, 13, 35, 0);
            DateTime departureTime = new DateTime(2024, 04, 17, 12, 0, 0);

            // Act

            // Assert
            Assert.ThrowsException<System.ArgumentException>(() => HelperFunctions.ParkedTimeAmount(arrivalTime, departureTime) );
        }
    }
}