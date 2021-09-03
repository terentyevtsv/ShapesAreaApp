using System;

namespace ShapesAreaApp.AreaCalculatorLib.Exceptions
{
    public class ShapePointsRequiredException : Exception
    {
        public ShapePointsRequiredException() : base("Фигура должна состоять из точек!")
        {
        }
    }
}
