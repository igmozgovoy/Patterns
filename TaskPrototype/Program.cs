using System;

namespace TaskPrototype
{
    public class Point
    {
        public int X, Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class Line
    {
        public Point Start, End;
        
        public Line(int startX, int startY, int endX, int endY)
        {
            Start = new Point(startX, startY);
            End = new Point(endX, endY);
        }

        public Line DeepCopy()
        {
            var clonedStart = new Point(Start.X, Start.Y);
            var clonedEnd = new Point(End.X, End.Y);
            return new Line(clonedStart.X, clonedStart.Y, clonedEnd.X, clonedEnd.Y);
        }

        public override string ToString()
        {
            return $"Start - {Start.X}, {Start.Y}\nEnd - {End.X}, {End.Y}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var line = new Line(1, 1, 10, 10);
            var clonedLine = line.DeepCopy();

            Console.WriteLine(line.ToString());
            Console.WriteLine(clonedLine.ToString());
            
            Console.WriteLine("\n-------------------------------------\n");

            clonedLine.Start.X = 2;
            clonedLine.Start.Y = 2;
            clonedLine.End.X = 100;

            Console.WriteLine(line.ToString());
            Console.WriteLine(clonedLine.ToString());

        }
    }
}
