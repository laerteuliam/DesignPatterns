using System;
using System.Collections.Generic;
using System.Text;

namespace StructuralLibrary.Bridge
{
    public interface IRenderer
    {
        void RenderCircle(float radius);
    }

    public class VectorRender : IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"Drawing a circle of radius {radius}");
        }
    }

    public class RasterRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"Drawing pixels for circle of radius");
        }
    }

    public abstract class Shape
    {
        protected readonly IRenderer _render;
        public Shape(IRenderer render)
        {
            _render = render;
        }
        public abstract void Draw();
        public abstract void Resize(float factor);
    }

    public class Circle : Shape
    {
        private float _radius;

        public Circle(IRenderer render, float radius) : base(render)
        {
            _radius = radius;
        }

        public override void Draw()
        {
            _render.RenderCircle(_radius);
        }

        public override void Resize(float factor)
        {
            _radius *= factor;
        }
    }
}
