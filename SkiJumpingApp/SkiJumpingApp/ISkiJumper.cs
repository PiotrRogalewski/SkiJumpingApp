using static SkiJumpingApp.SkiJumperBase;

namespace SkiJumpingApp
{
    public interface ISkiJumper
    {
        string Name { get; }

        string Surname { get; }

        string Country { get; }

        int Age { get; }

        void AddJumpDistance(float meters);

        void AddJumpDistance(string meters);

        event JumpDistanceAddedToListDelegate JumpDistanceAddedToList;

        Statistics GetStatistics();
    }
}
