using System;
using System.IO;

namespace Problem1
{
    class Program
    {
        const string FILE_PATH = "Day1In";
        
        static void Main(string[] args)
        {
            string[] sInputs = File.ReadAllLines(FILE_PATH);
            int[] nInputs = new int[sInputs.Length];
            int total = 0;

            //Convert to ints
            for(int i = 0; i < sInputs.Length; i++)
            {
                if(int.TryParse(sInputs[i], out  int output))
                {
                    nInputs[i] = output;
                    total += ComputeMass(nInputs[i]);
                    
                }
                else
                {
                    Console.WriteLine($"Error at index {i}");
                }

            }

            Console.WriteLine($"Total is: {total}");
            Console.ReadKey();
        }

        private static int ComputeMass(int input)
        { 
            int fuel = input/3 -2;
            if(fuel <= 0)
            {
                return 0;
            }
            else
            {
                return fuel + ComputeMass(fuel);
            }
        }
    }
}
