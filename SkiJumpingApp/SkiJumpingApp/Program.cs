using SkiJumpingApp;

internal class Program
{
    private static bool initialGreeting = true;

    private static void Main()
    {
        SkiJumperInMemory? skiJumperInMemory = null;
        var exit = false;
        string? savingMethodSelection = null;
        Statistics? statistics = null;

        while (!exit)
        {
            Welcome();
            TextInColor(ConsoleColor.White, "\n Select the ski jumper for whom you want to add jump distance to his jumping statistics.\n To do this - please type the number assigned to the ski jumper and then press ENTER button.\n\n 1 - Kamil Stoch\n 2 - Dawid Kubacki\n 3 - Piotr Żyła\n\n");

            var skiJumperSelection = Console.ReadLine();

            switch (skiJumperSelection)
            {
                case "1":
                    var skiJumper1 = new SkiJumperInMemory("Kamil", "Stoch", "Poland", 36);
                    skiJumperInMemory = skiJumper1;
                    exit = true;
                    break;
                case "2":
                    var skiJumper2 = new SkiJumperInMemory("Dawid", "Kubacki", "Poland", 33);
                    skiJumperInMemory = skiJumper2;
                    exit = true;
                    break;
                case "3":
                    var skiJumper3 = new SkiJumperInMemory("Piotr", "Żyła", "Poland", 36);
                    skiJumperInMemory = skiJumper3;
                    exit = true;
                    break;
                default:
                    TextInColor(ConsoleColor.Red, "\n Wrong choice, try again!\n");
                    continue;

            }
        }

        var skiJumperInFile = new SkiJumperInFile($"{skiJumperInMemory.Name}", $"{skiJumperInMemory.Surname}", $"{skiJumperInMemory.Country}", skiJumperInMemory.Age);
        exit = false;

        do
        {
            TextInColor(ConsoleColor.DarkGreen, "\n Please select saving method by typing right number and then press ENTER button.\n\n 1 - Saving to the file\n 2 - Saving to the program memory (temporary - until you quit the program)\n\n");
            savingMethodSelection = Console.ReadLine();

            if (savingMethodSelection == "1")
            {
                TextInColor(ConsoleColor.Green, "\n You have chosen to save the data to a file\n");
                exit = true;
            }
            else if (savingMethodSelection == "2")
            {
                TextInColor(ConsoleColor.Green, "\n You have chosen to save the data to program memory\n");
                exit = true;
            }
            else
            {
                TextInColor(ConsoleColor.Red, "\n Wrong choice, try again!\n");
                continue;
            }
        } while (!exit);

        while (savingMethodSelection != null)
        {
            TextInColor(ConsoleColor.DarkGreen, "\n Enter the length of the jump in meters (you can also enter a value after a decimal point),\n then press ENTER button. Use only digits, no words or letters.\n");
            var input = Console.ReadLine();

            if (input == "q")
            {
                break;
            }

            try
            {
                if (savingMethodSelection == "1")
                {
                    skiJumperInFile.AddJumpDistanceInMeters(input);
                }
                else if (savingMethodSelection == "2")
                {
                    skiJumperInMemory.AddJumpDistanceInMeters(input);
                }
                else
                {
                    TextInColor(ConsoleColor.Red, " Something went wrong!\n This savingMethodSelection shouldn't be null.\n ");
                }
            }
            catch (Exception exception)
            {
                TextInColor(ConsoleColor.Red, $"\n Warning! Exception catched. \n {exception.Message}\n");
            }
            finally
            {
                TextInColor(ConsoleColor.DarkGray, "\n To quit and show statistics type 'q', then press ENTER button.\n");
            }
        }

        if (savingMethodSelection == "1")
        {
            statistics = skiJumperInFile.GetStatistics();
        }
        else if (savingMethodSelection == "2")
        {
            statistics = skiJumperInMemory.GetStatistics();
        }

        TextInColor(ConsoleColor.Yellow, $"\n Statistics of the jumps for {skiJumperInMemory.Name} {skiJumperInMemory.Surname} from {skiJumperInMemory.Country}, {skiJumperInMemory.Age} years old.\n" +
            $"\n The best jump:                     {statistics.Max} m" +
            $"\n The worst jump:                    {statistics.Min} m" +
            $"\n Number of jumps:                   {statistics.Count}" +
            $"\n Ski jumping average:               {statistics.SkiJumpingAverage} m" +
            $"\n Ski jumper class (A is the best):  {statistics.SkiJumpingAverageAsLetter}");

        ChangeSkiJumperOrExit();
    }

    private static void ChangeSkiJumperOrExit()
    {
        while (true)
        {
            TextInColor(ConsoleColor.Cyan, "\n What next?\n\n >>> to change the ski jumper click:        'c' button and then press ENTER button\n >>> to exit from the program click:        'x' or 'q' button, then press ENTER button\n");
            var nextMove = Console.ReadLine();

            if (nextMove == "c")
            {
                initialGreeting = false;
                Main();
                break;
            }
            else if (nextMove == "x" || nextMove == "q")
            {
                TextInColor(ConsoleColor.Magenta, "\n Catch the wind and fly high! See yaa! :) \n\n\n======================================================================================================================\n                                        To exit the program, press any key\n======================================================================================================================");
                break;
            }
            else
            {
                TextInColor(ConsoleColor.Red, "\n Wrong choice! Try again!\n");
                continue;
            }
        }
    }

    private static void Welcome()
    {
        if (initialGreeting == true)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("======================================================================================================================\n                                              Welcome in SkiJumpingApp !                                              \n======================================================================================================================\n");
            Console.ResetColor();
        }
    }

    private static void TextInColor(ConsoleColor color, string text)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();
    }
}   