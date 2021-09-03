using System;
using System.Linq;
using ShapesAreaApp.AreaCalculatorLib.Models;
using ShapesAreaApp.AreaCalculatorLib.Models.Shapes;

namespace ShapesAreaApp.AreaCalculatorLib.Factory
{
    public class ShapesFactory
    {
        private readonly double _tolerance;

        public ShapesFactory(double tolerance)
        {
            _tolerance = tolerance;
        }

        /// <summary>
        /// Создание круга
        /// </summary>
        /// <param name="radius">радиус</param>
        /// <returns></returns>
        public Circle CreateCircle(double radius)
        {
            return new Circle(radius);
        }

        /// <summary>
        /// Создание треугольника
        /// </summary>
        /// <param name="a">1 сторона</param>
        /// <param name="b">2 сторона</param>
        /// <param name="c">3 сторона</param>
        /// <returns></returns>
        public Triangle CreateTriangle(double a, double b, double c)
        {
            // Проверка является ли треугольник прямоугольным
            var lengths = new[]
            {
                a,
                b,
                c
            };

            var maxValue = lengths.Max();

            double counter2 = 0.0;
            var values = new double[2];
            int i = 0;

            foreach (var length in lengths)
            {
                var isEqual = Math.Abs(length - maxValue) < _tolerance;
                if (isEqual)
                    continue;

                values[i++] = length;
                counter2 += Math.Pow(length, 2);
            }

            var maxValue2 = Math.Pow(maxValue, 2);

            var isTmpEqual = Math.Abs(maxValue2 - counter2) < _tolerance;
            if (!isTmpEqual)
                return new Triangle(a, b, c, _tolerance);

            return new RightTriangle(
                values[0], 
                values[1], 
                maxValue, 
                _tolerance);
        }

        /// <summary>
        /// Создание произвольной фигуры
        /// </summary>
        /// <param name="points">Координаты всех вершин</param>
        /// <returns></returns>
        public Shape CreateShape(Point[] points)
        {
            return new Shape(points);
        }
    }
}
