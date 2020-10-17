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
        class Segment
        {
            private double a;
            private double b;
            private double c;
            private double x1;
            private double x2;
            private double y1;
            private double y2;

            public double A { get => a;}
            public double B { get => b;}
            public double C { get => c;}
            public double Y2 { get => y2;}
            public double Y1 { get => y1;}
            public double X2 { get => x2;}
            public double X1 { get => x1;}

            public Segment(Node origin, Node destination)
            {
                a  = destination.y - origin.y;
                b = origin.x - destination.x;
                c = a*origin.x + b*origin.y;
                x1 = origin.x;
                x2 = destination.x;
                y1 = origin.y;
                y2 = destination.y;
            }
        }
        
        struct Node
        {
            public double x;
            public double y;
            public override string ToString()
            {
                return $"x: {x},y: {y}";
            }
        }
        const string FILE_PATH = "input.txt";
        const int DIRECTION_CHAR_INDEX = 0;
        const int DIRECTION_CHAR_LENGTH = 1;
        const int MAGNITUDE_START_INDEX = 1;
        const int EARLIERST_INTERCEPT = 3;
        
        static void Main(string[] args)
        {
            List<Node> nodes = GenerateNodeList();
            List<Segment> segments = new List<Segment>();
            List<Node> intercepts = new List<Node>();
            List<double> manhattanDistances = new List<double>();
            for(int i = 0; i < nodes.Count-1; i++)
            {
                segments.Add(new Segment(nodes[i],nodes[i+1]));
            }
            //locate intercepts
            for(int i = 0; i<segments.Count-3;i++)
            {
                Segment seg1 = segments[i];
                Segment seg2 = segments[i+EARLIERST_INTERCEPT];

                double determinant = seg1.A*seg2.B-seg2.A*seg1.B;
                if(determinant!=0)//if determinant == 0, lines are parallel, no intercepts
                {
                    /*
                        x = (B2*C1 - B1*C2)/det
                        y = (A1*C2 - A2*C1)/det  
                    */
                    double x = (seg2.B * seg1.C - seg1.B*seg2.C)/determinant;
                    double y = (seg1.A * seg2.C - seg2.A*seg1.C)/determinant;
                    //check to see if the co-ordinate is on either line
                    if(Math.Min(seg1.X1,seg1.X2)<= x && Math.Max(seg1.X1, seg1.X2)>=x)
                    {
                        if(Math.Min(seg1.Y1,seg1.Y2) <= y && Math.Max(seg1.Y1,seg1.Y2) >= y)
                        {
                            Node intercept = new Node();
                            intercept.x = x;
                            intercept.y = y;
                            intercepts.Add(intercept);
                        }
                    }
                }
            }
            for (int i = 0; i < intercepts.Count; i++)
            {
                manhattanDistances.Add(ManhattanDistance(intercepts[i].x,intercepts[i].y));
            }

            manhattanDistances.Sort();
            foreach(double distance in manhattanDistances)
            {
                Console.WriteLine($"Distance to intercept: {distance}");
            }
            Console.ReadKey();
            
        }
        // Manhattan distance
        static double ManhattanDistance(double x, double y)
        {
            return Math.Abs(x) + Math.Abs(y);
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
        //Parse command into something useable
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
        //Generate a node based on a previous command
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
        //Generate a list of nodes
        static List<Node> GenerateNodeList()
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
