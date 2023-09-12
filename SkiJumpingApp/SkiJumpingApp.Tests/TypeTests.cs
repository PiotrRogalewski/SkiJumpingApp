namespace SkiJumpingApp.Tests
{
    public class TypeTests
    {
        [Test]
        public void WhenComparingTwoSkiJumpers_ShouldCheckIfTheyAreDifferentObject()
        {
            var skiJumper1 = GetSkiJumper("Maciej", "Kot", "Poland", 32);
            var skiJumper2 = GetSkiJumper("Adrzej", "Stękała", "Poland", 28);

            Assert.AreNotEqual(skiJumper1, skiJumper2);
        }

        [Test]
        public void WhenComparingTwoVars_ShouldCheckIfTheyAreTheSameObject()
        {
            var skiJumper3 = GetSkiJumper("Klemens", "Murańka", "Poland", 29);
            var skiJumper4 = skiJumper3;

            Assert.AreEqual(skiJumper3, skiJumper4);
        }


        private SkiJumperInMemory GetSkiJumper(string name, string surname, string country, int age)
        {
            return new SkiJumperInMemory(name, surname, country, age);
        }
    }
}
