using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace day4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> identificationInfo = new List<string>();
            const string TEST_PATH = @"C:\Users\tim\repos\AdventOfCode\2020-4\day4\testInpu.txt";
            const string FILE_PATH = @"C:\Users\tim\repos\AdventOfCode\2020-4\day4\input.txt";
            string[] lines = File.ReadAllLines(FILE_PATH);
            StringBuilder sb = new StringBuilder();
            int passports = 0;
            for(int i = 0; i< lines.Length; i++)
            {
                string line = lines[i];
                if (line != string.Empty)
                {
                    //Console.WriteLine(line + " ");
                    sb.Append(line + " ");
                }
                else
                {
                    identificationInfo.Add(sb.ToString());
                    passports++;
                    sb.Clear();
                }

            }
            //Not sure why this isn't working, but oh well
            string[] fields = { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid", "cid" };
            Console.WriteLine($"Number of Passports: {passports}");
            int validPassports = 0;
            foreach (string id in identificationInfo)
            {
                bool valid = false;
                int count = 0;
                foreach (string field in fields)
                {
                    if (id.Contains(field))
                    {
                        count++;
                    }
                    
                }
                if (count == 7)
                {
                    if (id.Contains(fields[7]))
                    {
                        valid = true;
                    }
                }
                else if (count == 8)
                {
                    valid = true;
                }
                if (valid)
                {
                    validPassports++;
                }
            }
            Console.WriteLine($"valid passports: {validPassports}");
            Console.ReadKey();
        }
    }
}
