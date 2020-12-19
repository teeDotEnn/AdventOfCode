using System;
using System.IO;
namespace _2020_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"C:\Users\tim\repos\AdventOfCode\2020-2\input.txt");
            int valid = 0;
            valid = partTwo(input);

            Console.WriteLine($"{valid }");
        }

        private int partOne(string[] input)
        {
            int valid = 0;
            foreach (string line in input)
            {
                string[] parts = line.Split(" ");
                string[] range = parts[0].Split("-");
                char letter = parts[1][0];
                int count = 0;
                foreach (char c in parts[2])
                {
                    if (c == letter)
                    {
                        count++;
                    }
                }
                if (count >= int.Parse(range[0]) && count <= int.Parse(range[1]))
                {
                    valid++;
                }


            }
            return valid;
        }

        private static int partTwo(string[] input)
        {

            int validPasswords = 0;
            foreach (string line in input)
            {
                bool valid = false;
                string[] parts = line.Split(" ");
                string[] range = parts[0].Split("-");
                int posOne = int.Parse(range[0])-1;
                int posTwo = int.Parse(range[1])-1;
                char letter = parts[1][0];
                
                if(parts[2][posOne] == letter || parts[2][posTwo] == letter)
                {
                    valid = true;
                }
                if(parts[2][posOne] == letter && parts[2][posTwo] == letter)
                {
                    valid = false;
                }
                if(valid)
                {
                    Console.WriteLine($"Password Valid: {parts[2]}");
                    validPasswords++;
                }

            }
            return validPasswords;
        }
    }
}
