namespace SkiJumpingApp
{
    public abstract class SkiJumperBase : ISkiJumper
    {
        public delegate void JumpDistanceAddedToListDelegate(object sender, EventArgs args);

        public event JumpDistanceAddedToListDelegate JumpDistanceAddedToList;

        public SkiJumperBase(string name, string surname, string country, int age)
        {
            this.Name = name;
            this.Surname = surname;
            this.Country = country;
            this.Age = age;
        }

        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Country { get; private set; }
        public int Age { get; private set; }

        public abstract void AddJumpDistance(float meters);

        public virtual void AddJumpDistance(string meters)
        {
            if (float.TryParse(meters, out float metersInFloatValue))
            {
                this.AddJumpDistance(metersInFloatValue);
            }
            else
            {
                throw new Exception("\n Text that contains letters and that is not a number is not allowed!\n Enter the jump distance from 0 to 253,5 (meters). Remember! Type only number of meters, no words or letters.\n");
            }
        }

        protected void ShootEvent()
        {
            if (JumpDistanceAddedToList != null)
            {
                JumpDistanceAddedToList(this, new EventArgs());
            }
        }

        public abstract Statistics GetStatistics();
    }
}
