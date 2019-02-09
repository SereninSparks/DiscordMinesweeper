using System;
using System.Linq;

namespace MinesweeperBot
{
    class Program
    {
        static void Main(string[] args) => new Program().Run();

        public void Run()
        {
            var fieldParams = AskParams();
            Console.WriteLine(fieldParams);
            Console.ReadKey();
        }

        private MinesweeperParams AskParams()
        {
            Console.WriteLine("Please provide the params for the minesweeper board");
            Console.WriteLine("<size> <mines>");
            Console.WriteLine("<width> <height> <mines>");
            string[] args = Console.ReadLine().Split(' ');

            try
            {
                int[] parsedArgs = args.Select(arg => int.Parse(arg)).ToArray();

                if (parsedArgs.Length <= 1)
                {
                    return AskParams();
                }

                return new MinesweeperParams(parsedArgs);
            }
            catch
            {
                return AskParams();
            }
        }
    }
}
