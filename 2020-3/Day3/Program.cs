using System;
using System.IO;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"C:\Users\tim\repos\AdventOfCode\2020-3\Day3\input.txt");
            string[,] map = new string[input.Length, input[0].Length];
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[0].Length; j++)
                {
                    //.....#.##......#..##..........#
                    map[i, j] = input[i][j].ToString();
                }
            }
            long trees1 = treesHit(1, 3, map);
            long trees2 = treesHit(1, 1, map);
            long trees3 = treesHit(1, 5, map);
            long trees4 = treesHit(1, 7, map);
            long trees5 = treesHit(2, 1, map);
            long output = trees1 * trees2 * trees3 * trees4 * trees5;
            
            
            Console.WriteLine($"output: {output} ");
            Console.ReadKey();
        }
        static int treesHit(int down, int right, string[,] map)
        {
            int trees = 0;
            int row = 0;
            int col = 0;
            string ptr;

            //Slope is right 3, down 1
            for (int i = 0; i < map.GetLength(0); i++)
            {
                if(row > map.GetLength(0))
                {
                    return trees;
                }
                ptr = map[row, col];
                //check for a tree at current location
                if (ptr == "#")
                {
                    trees++;
                }
                //increment row by 1
                row += down;
                //increment cols by 3
                col += right;
                //check if we need to wrap
                if (col >= map.GetLength(1))
                {
                    col = col - map.GetLength(1);
                }

            }
            return trees;
        }
    }
}
