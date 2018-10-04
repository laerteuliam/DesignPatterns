using Autofac;
using Autofac.Core;
using StructuralLibrary.Bridge;
using System;

namespace Structural.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Bridge();
            DIBridge();
            Console.Read();
        }

        #region Bridge
        private static void Bridge()
        {
            IRenderer render = new VectorRender();
            Circle circle = new Circle(render, 10);
            circle.Draw();
            circle.Resize(2);
            circle.Draw();

            render = new RasterRenderer();
            Circle circle2 = new Circle(render, 10);
            circle2.Draw();
            circle2.Resize(2);
            circle2.Draw();
        }

        private static void DIBridge()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<VectorRender>()
                .As<IRenderer>()
                .SingleInstance();

            containerBuilder
                .Register((c, p)
                    => new Circle(c.Resolve<IRenderer>(),
                        p.Positional<float>(0)));

            using (var container = containerBuilder.Build())
            {
                Circle circle = container.Resolve<Circle>(new PositionalParameter(0, 5.0f));
                circle.Draw();
                circle.Resize(2);
                circle.Draw();
            }
        }
        #endregion
    }
}
