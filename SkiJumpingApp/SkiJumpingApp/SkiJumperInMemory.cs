namespace SkiJumpingApp
{
    public class SkiJumperInMemory : SkiJumperBase
    {
        private List<float> allJumpDistances = new List<float>();

        public SkiJumperInMemory(string name, string surname, string country, int age)
            : base(name, surname, country, age)
        {
        }

        public override void AddJumpDistanceInMeters(float meters)
        {
            if (meters >= 0 && meters <= 253.5)
            {
                this.allJumpDistances.Add(meters);
            }
            else if (meters > 253.5 && meters <= 256)
            {
                throw new Exception("\n Wow! This is a new world record in ski jumping!\n If this really happens, let me know immediately! (Tanard from gotoit group) ;) \n But now please stop dreaming and enter the correct jump distance from 0 to 253.5 (meters).\n");
            }
            else
            {
                throw new Exception("\n This distance is out of range! Enter the jump distance from 0 to 253.5 (meters).\n");
            }
        }

        public override void AddJumpDistanceInMeters(string meters)
        {
            base.AddJumpDistanceInMeters(meters);
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            foreach (var meters in allJumpDistances)
            {
                statistics.AddJumpInMeters(meters);    
            }

            return statistics;
        }
    }
}
