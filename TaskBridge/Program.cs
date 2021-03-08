using System;

namespace TaskBridge
{

    public interface IRenderer 
    { 
        public string WhatToRenderAs { get; }
    }

    public class VectorRender : IRenderer 
    {
        public string WhatToRenderAs { get { return "vectors"; } }
    }

    public class RasterRender : IRenderer
    {
        public string WhatToRenderAs { get { return "pixels"; } }
    }

    public abstract class Shape 
    {
        public string Name { get; set; }
        protected IRenderer renderer;
        public Shape(IRenderer renderer)
        {
            this.renderer = renderer;
        }
    }

    public class Triangle : Shape
    {
        public Triangle(IRenderer renderer) : base(renderer)
        {
            Name = "Triangle";
        }

        public override string ToString()
        {
            return $"Drawing {Name} as {renderer.WhatToRenderAs}";
        }
    }

    public class Square : Shape
    {
        public Square(IRenderer renderer) : base (renderer)
        {
            Name = "Square";
        }

        public override string ToString()
        {
            return $"Drawing {Name} as {renderer.WhatToRenderAs}";
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            var triangle = new Triangle(new VectorRender());
            var square = new Square(new RasterRender());

            Console.WriteLine(triangle.ToString());
            Console.WriteLine(square.ToString());

        }
    }
}
