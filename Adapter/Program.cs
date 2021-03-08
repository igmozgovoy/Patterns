using System;

namespace TaskAdapter
{
    public class Square 
    {
        public int Side;
    }


    public interface IRectangle
    {
        public int Width { get;  }
        public int Height { get; }
    }

    public static class ExtensionMethods
    {
        public static int Area ( this IRectangle rc )
        {
            return rc.Width * rc.Height;
        }

    }

    public class SquareToRectangleAdapter : IRectangle
    {
        int side;
        int IRectangle.Width { get { return side; }  }
        int IRectangle.Height { get { return side; } }
        public SquareToRectangleAdapter(Square square)
        {
            side = square.Side;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            IRectangle square = new SquareToRectangleAdapter(new Square { Side = 100 });
            Console.WriteLine(square.Area());

    
        }
    }
}
