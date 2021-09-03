using System;

namespace ShapesAreaApp.AreaCalculatorLib.Exceptions
{
    public class ZeroOrNegativeWidthException : Exception
    {
        public ZeroOrNegativeWidthException(string message) 
            : base(message)
        {
        }
    }
}
