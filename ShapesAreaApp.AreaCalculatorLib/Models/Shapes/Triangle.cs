using System;
using ShapesAreaApp.AreaCalculatorLib.Exceptions;

namespace ShapesAreaApp.AreaCalculatorLib.Models.Shapes
{
    public class Triangle : Shape
    {
        protected readonly double LengthA;
        protected readonly double LengthB;
        protected readonly double LengthC;
        protected readonly double Tolerance;

        public Triangle(double a, double b, double c, double tolerance)
        {
            if (a <= 0 || b <= 0 || c <= 0)
                throw new ZeroOrNegativeWidthException("Длины сторон должны быть положительными!");

            // Сумма двух любых сторон всегда больше третьей
            var isTriangle = (a + b > c) && (b + c > a) && (c + a > b);
            if (!isTriangle)
                throw new ShapeIsNotTriangleException();

            LengthA = a;
            LengthB = b;
            LengthC = c;
            Tolerance = tolerance;
        }

        public override double GetArea()
        {
            var p = (LengthA + LengthB + LengthC) * 0.5;
            var area = Math.Sqrt(p * (p - LengthA) * (p - LengthB) * (p - LengthC));

            return area;
        }
    }
}
