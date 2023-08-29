namespace SkiJumpingApp
{
    public class SkiJumperInFile : SkiJumperBase
    {
        private const string emptyFile = "_all_jumping_distances";
        private string? fileWithFullName = null;

        public SkiJumperInFile(string name, string surname, string country, int age)
            : base(name, surname, country, age)
        {
            fileWithFullName = $"{emptyFile}" + $"_of_{name}_{surname}";
        }

        public override void AddJumpDistanceInMeters(float meters)
        {
            if (meters > 0 && meters <= 253.5)
            {
                using (var writer = File.AppendText(fileWithFullName))
                {
                    writer.WriteLine(meters);
                }
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

        private List<float> ReadMetersFromFile()
        {
            var allJumpDistances = new List<float>();

            if (File.Exists($"{fileWithFullName}"))
            {
                using (var reader = File.OpenText($"{fileWithFullName}"))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = float.Parse(line);
                        allJumpDistances.Add(number);
                        line = reader.ReadLine();
                    }
                }
            }
            else
            {
                throw new Exception("\n The file does not exist or has just been created.\n");
            }

            return allJumpDistances;
        }

        private Statistics CountStatistics(List<float> allJumpDistances)
        {
            var statistics = new Statistics();

            foreach (var meters in allJumpDistances)
            {
                statistics.AddJumpInMeters(meters);
            }

            return statistics;
        }
            

        public override Statistics GetStatistics()
        {
            var metersFromFile = this.ReadMetersFromFile();
            var result = this.CountStatistics(metersFromFile);

            return result;
        }
    }
}
