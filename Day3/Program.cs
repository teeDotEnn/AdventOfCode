using System;
using System.Collections.Generic;
using System.IO;

namespace Day3
{
    class Program
    {
        struct Command
        {
            public string axis;
            public int magnitude;
            
        }

        struct Node
        {
            public int x;
            public int y;

        }
        const string FILE_PATH = "input.txt";
        const int DIRECTION_CHAR_INDEX = 0;
        const int DIRECTION_CHAR_LENGTH = 1;
        const int MAGNITUDE_START_INDEX = 1;
        
        static void Main(string[] args)
        {
            List<Node> Route = GenerateRoute();
            

        }
        // Manhattan distance
        int ManhattanDistance(int x1, int x2, int y1, int y2)
        {
            return Math.Abs(x2-x1) + Math.Abs(y2-y1);
        }

        // load file
        static List<String> LoadFile()
        {
            List<String> output = new List<string>();
            string[] lines  = File.ReadAllLines(FILE_PATH);
            foreach(string line in lines)
            {
                string[] arr = line.Split(',');
                foreach(string command in arr)
                {
                    output.Add(command);
                }
            }
            return output;
        }
        static Command ParseInput(string command)
        {
            Command outputCommand = new Command();
            int magnitude = int.Parse(command.Substring(MAGNITUDE_START_INDEX));
            switch(command.Substring(DIRECTION_CHAR_INDEX,DIRECTION_CHAR_LENGTH))
            {
                case "U":
                outputCommand.axis = "X";
                //outputCommand.direction = true;
                outputCommand.magnitude = magnitude;
                break;
                case "D":
                outputCommand.axis = "X";
                //outputCommand.direction = false;
                outputCommand.magnitude =  magnitude * -1;
                break;
                case "L":
                outputCommand.axis = "Y";
                outputCommand.magnitude =  magnitude* -1;
                //outputCommand.direction = false;
                break;
                case "R":
                outputCommand.axis = "Y";
                outputCommand.magnitude = magnitude;
                //outputCommand.direction = true;
                break;
            }
            ;
            return outputCommand;
        }
        static Node GenerateNode(Command command, Node previousNode)
        {
            Node outputNode = previousNode;
            if(command.axis == "X")
            {
                outputNode.x += command.magnitude;
            }
            else
            {
                outputNode.y += command.magnitude;
            }
            return outputNode;
        }

        static List<Node> GenerateRoute()
        {
            List<Node> outputNodes = new List<Node>();

            List<String> commands = LoadFile();
            Node firstNode = new Node();
            firstNode.x = 0;
            firstNode.y = 0;
            outputNodes.Add(firstNode);
            


            for (int i = 0; i < commands.Count; i++)
            {
                Command command = ParseInput(commands[i]);
                outputNodes.Add(GenerateNode(command,outputNodes[i]));

            }
            return outputNodes;
        }
        
        // find intercept?
    }
}
