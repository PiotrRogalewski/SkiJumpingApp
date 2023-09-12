namespace SkiJumpingApp
{
    public class Statistics
    {
        public float Min { get; private set; }

        public float Max { get; private set; }

        public float Sum { get; private set; }

        public int Count { get; private set; }

        public float SkiJumpingAverage
        {
            get
            {
                var average = this.Sum / this.Count;
                average = (float)Math.Round(average, 2);
                return average;
            }
        }

        public char SkiJumpingAverageAsLetter
        {
            get
            {
                switch (this.SkiJumpingAverage)
                {
                    case var average when average >= 140:
                        return 'A';
                    case var average when average >= 125:
                        return 'B';
                    case var average when average >= 110:
                        return 'C';
                    case var average when average >= 95:
                        return 'D';
                    case var average when average >= 80:
                        return 'E';
                    default:
                        return 'F';
                }
            }
        }

        public Statistics()
        {
            this.Min = float.MaxValue;
            this.Max = float.MinValue;
            this.Sum = 0;
            this.Count = 0;
        }

        public void AddJumpDistance(float meters)
        {
            this.Count++;
            this.Sum += meters;
            this.Min = Math.Min(meters, this.Min);
            this.Min = (float)Math.Round(this.Min, 2);
            this.Max = Math.Max(meters, this.Max);
            this.Max = (float)Math.Round(this.Max, 2);
        }
    }
}
