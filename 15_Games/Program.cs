namespace _15_Games;
class Program
{
    private static int[,] numbers = 
    { 
        { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, default, 15 } 
    };

    private static int x = 0;
    private static int y = 0;
    /// <summary>
    /// :) Main Funcsion
    /// </summary>
    /// <param name="args"></param>
    private static void Main(string[] args)
    {
        ShowConsole(numbers);

        while (true)
        {
            var choose = Console.ReadKey(false).Key;
            switch (choose)
            {
                case ConsoleKey.Escape:
                    Console.WriteLine("Press the Escape, if you wont to exit game :(");
                    return;

                case ConsoleKey.UpArrow:
                    Limits(x, y, x - 1, y);
                    break;

                case ConsoleKey.DownArrow:
                    Limits(x, y, x + 1, y);
                    break;

                case ConsoleKey.LeftArrow:
                    Limits(x, y, x, y - 1);
                    break;

                case ConsoleKey.RightArrow:
                    Limits(x, y, x, y + 1);
                    break;

                case ConsoleKey.Enter:
                    ShuffleNumbers();
                    break;
            }
            Console.Clear();

            ShowConsole(numbers);

            if (CheckWin(numbers))
            {
                Console.WriteLine("\n\t# YOU WON :)");
            }
        }
    }

    /// <summary>
    /// To Show Console
    /// </summary>
    /// <param name="numbers"></param>
    private static void ShowConsole(int[,] numbers)
    {

        Console.WriteLine("\n\t+++++++++++++++++++++");
        for (int iterator = 0; iterator < numbers.GetLength(0); iterator++)
        {
            Console.Write("\t| ");
            for (int _iterator = 0; _iterator < numbers.GetLength(1); _iterator++)
            {
                if (numbers[iterator, _iterator] < 10)
                {
                    Console.Write(" ");
                }
                if (numbers[iterator, _iterator] == default)
                {
                    x = iterator;
                    y = _iterator;
                    Console.Write("  | ");
                }
                else
                {
                    Console.Write(numbers[iterator, _iterator] + " | ");
                }
            }
            Console.WriteLine("\n\t+++++++++++++++++++++");
        }
    }

    /// <summary>
    /// To Determine the Boundary Part of the Game
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="x1"></param>
    /// <param name="y1"></param>
    private static void Limits(int x, int y, int x1, int y1)
    {
        if (x1 >= numbers.GetLength(0) || x1 < 0 || y1 >= numbers.GetLength(1) || y1 < 0)
        {
            Console.Beep(2000, 100);
            return;
        }
        numbers[x, y] = numbers[x1, y1];
        numbers[x1, y1] = default;
    }

    /// <summary>
    /// To Check if it Won
    /// </summary>
    /// <param name="numbers"></param>
    /// <returns></returns>
    private static bool CheckWin(int[,] numbers)
    {
        int counter = 1;
        foreach (int item in numbers)
        {
            if (counter != item) 
            { 
                return false; 
            }
            if (counter == numbers.Length - 1)
            {
                return true;
            }
            counter++;
        }

        return false;
    }

    /// <summary>
    /// To Mix Numbers
    /// </summary>
    private static void ShuffleNumbers()
    {
        for (int iterator = 0; iterator < numbers.GetLength(0); iterator++)
        {
            for (int _iterator = 0; _iterator < numbers.GetLength(1); _iterator++)
            {
                Random rnd = new Random();

                int x = rnd.Next(0, numbers.GetLength(0));
                int y = rnd.Next(0, numbers.GetLength(0));

                int a = numbers[iterator, _iterator];
                numbers[iterator, _iterator] = numbers[x, y];
                numbers[x, y] = a;
            }
        }
    }
}


