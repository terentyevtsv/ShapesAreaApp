using System;

namespace ShapesAreaApp.AreaCalculatorLib.Models
{
    public class Shape
    {
        private readonly Point[] _points;

        protected Shape()
        {
        }

        public Shape(Point[] points)
        {
            const int minShapeSize = 3;

            if (_points.Length < minShapeSize)
                throw new Exception("Фигура должна состоять из точек!");

            _points = points;
        }

        public virtual double GetArea()
        {
            double area = 0.0;

            int i;
            for (i = 0; i < _points.Length - 1; ++i)
            {
                area += _points[i].X * _points[i + 1].Y;
            }

            area += _points[++i].X * _points[0].Y;

            for (i = 0; i < _points.Length - 1; ++i)
            {
                area -= _points[i + 1].X * _points[i].Y;
            }

            area -= _points[0].X * _points[i].Y;

            return 0.5 * Math.Abs(area);
        }
    }
}
