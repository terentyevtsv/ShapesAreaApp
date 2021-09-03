namespace ShapesAreaApp.AreaCalculatorLib.Models.Shapes
{
    public class RightTriangle : Triangle
    {
        public RightTriangle(double leg1, double leg2, double hypotenuse, double tolerance) 
            : base(leg1, leg2, hypotenuse, tolerance)
        {
        }

        /// <summary>
        /// катет 1
        /// </summary>
        public double Leg1 => LengthA;

        /// <summary>
        /// катет 2
        /// </summary>
        public double Leg2 => LengthB;

        /// <summary>
        /// гипотенуза
        /// </summary>
        public double Hypotenuse => LengthC;

        public override double GetArea()
        {
            return 0.5 * Leg1 * Leg2;
        }
    }
}
