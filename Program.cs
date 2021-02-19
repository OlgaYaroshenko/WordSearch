using System;
using System.Collections.Generic;
using System.Linq;

namespace WordSearch
{
    internal class Program
    {
        private static readonly char[,] Grid =
        {
            {'C', 'P', 'K', 'X', 'O', 'I', 'G', 'H', 'S', 'F', 'C', 'H'},
            {'Y', 'G', 'W', 'R', 'I', 'A', 'H', 'C', 'Q', 'R', 'X', 'K'},
            {'M', 'A', 'X', 'I', 'M', 'I', 'Z', 'A', 'T', 'I', 'O', 'N'},
            {'E', 'T', 'W', 'Z', 'N', 'L', 'W', 'G', 'E', 'D', 'Y', 'W'},
            {'M', 'C', 'L', 'E', 'L', 'D', 'N', 'V', 'L', 'G', 'P', 'T'},
            {'O', 'J', 'A', 'A', 'V', 'I', 'O', 'T', 'E', 'E', 'P', 'X'},
            {'C', 'D', 'B', 'P', 'H', 'I', 'A', 'W', 'V', 'X', 'U', 'I'},
            {'L', 'G', 'O', 'S', 'S', 'B', 'R', 'Q', 'I', 'A', 'P', 'K'},
            {'E', 'O', 'I', 'G', 'L', 'P', 'S', 'D', 'S', 'F', 'W', 'P'},
            {'W', 'F', 'K', 'E', 'G', 'O', 'L', 'F', 'I', 'F', 'R', 'S'},
            {'O', 'T', 'R', 'U', 'O', 'C', 'D', 'O', 'O', 'F', 'T', 'P'},
            {'C', 'A', 'R', 'P', 'E', 'T', 'R', 'W', 'N', 'G', 'V', 'Z'}
        };

        private static readonly string[] Words =
        {
            "CARPET",
            "CHAIR",
            "DOG",
            "BALL",
            "DRIVEWAY",
            "FISHING",
            "FOODCOURT",
            "FRIDGE",
            "GOLF",
            "MAXIMIZATION",
            "PUPPY",
            "SPACE",
            "TABLE",
            "TELEVISION",
            "WELCOME",
            "WINDOW"
        };

        private static void Main(string[] args)
        {
            Console.WriteLine("Word Search");

            for (var y = 0; y < 12; y++)
            {
                for (var x = 0; x < 12; x++)
                {
                    Console.Write(Grid[y, x]);
                    Console.Write(' ');
                }

                Console.WriteLine("");
            }

            Console.WriteLine("");
            Console.WriteLine("Found Words");
            Console.WriteLine("------------------------------");

            FindWords();

            Console.WriteLine("------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Press any key to end");
            Console.ReadKey();
        }

        private static void FindWords()
        {
            //Find each of the words in the grid, outputting the start and end location of
            //each word, e.g.
            //PUPPY found at (10,7) to (10, 3)

            var strings = new List<string>();
            var tempString = "";

            // horizontal
            for (var x = 0; x < 12; x++)
            {
                for (int y = 0; y < 12; y++)
                {
                    var currentCharacter = Grid[x, y];
                    tempString += currentCharacter;
                }

                strings.Add(tempString);
                strings.Add(new string(tempString.Reverse().ToArray()));
                tempString = "";
            }

            // vertical
            for (var x = 0; x < 12; x++)
            {
                for (var y = 0; y < 12; y++)
                {
                    var currentCharacter = Grid[y, x];
                    tempString += currentCharacter;
                }

                strings.Add(tempString);
                strings.Add(new string(tempString.Reverse().ToArray()));
                tempString = "";
            }

            // print found
            foreach (var word in Words)
            {
                foreach (var st in strings.Where(str => str.Contains(word)))
                {
                    PrintResult(word);
                }
            }
        }

        private static void PrintResult(string word) { Console.WriteLine($"{word} found."); }
    }
}