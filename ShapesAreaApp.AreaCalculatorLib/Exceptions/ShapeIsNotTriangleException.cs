using System;

namespace ShapesAreaApp.AreaCalculatorLib.Exceptions
{
    public class ShapeIsNotTriangleException : Exception
    {
        public ShapeIsNotTriangleException() : base("Фигура не треугольник!")
        {
        }
    }
}
