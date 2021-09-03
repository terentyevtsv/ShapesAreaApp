using System;
using ShapesAreaApp.AreaCalculatorLib.Exceptions;

namespace ShapesAreaApp.AreaCalculatorLib.Models.Shapes
{
    public class Circle : Shape
    {
        private readonly double _radius;

        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ZeroOrNegativeWidthException("Радиус должен быть положительным!");

            _radius = radius;
        }

        public override double GetArea()
        {
            const int squarePower = 2;

            // S = PI * R * R
            return Math.PI * Math.Pow(_radius, squarePower);
        }
    }
}
