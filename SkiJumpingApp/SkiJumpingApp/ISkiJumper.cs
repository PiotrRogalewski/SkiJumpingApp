using static SkiJumpingApp.SkiJumperBase;

namespace SkiJumpingApp
{
    public interface ISkiJumper
    {
        string Name { get; } 
        
        string Surname { get; }

        string Country { get; }

        int Age { get; }

        void AddJumpDistanceInMeters(float meters);

        void AddJumpDistanceInMeters(string meters);

        Statistics GetStatistics();
    }
}
