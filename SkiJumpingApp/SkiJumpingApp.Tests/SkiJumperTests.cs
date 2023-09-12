
namespace SkiJumpingApp.Tests
{
    public class Tests
    {
        [Test]
        public void WhenJumpsDistancesAreAdded_ShouldReturnCorrectStatistics()
        {
            // Arrange 
            var jumper1 = new SkiJumperInMemory("Adam", "Ma³ysz", "Poland", 40);
            jumper1.AddJumpDistance(89.5f);
            jumper1.AddJumpDistance(150);
            jumper1.AddJumpDistance(144);
            jumper1.AddJumpDistance(230.5f);
            jumper1.AddJumpDistance(111);

            // Act
            var result = jumper1.GetStatistics();

            // Assert
            Assert.AreEqual(230.5, result.Max);
            Assert.AreEqual(89, 5, result.Min);
            Assert.AreEqual(145, result.SkiJumpingAverage);

        }
    }
}