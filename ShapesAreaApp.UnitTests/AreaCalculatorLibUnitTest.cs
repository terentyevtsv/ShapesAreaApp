using NUnit.Framework;
using ShapesAreaApp.AreaCalculatorLib.Exceptions;
using ShapesAreaApp.AreaCalculatorLib.Factory;
using ShapesAreaApp.AreaCalculatorLib.Models;
using ShapesAreaApp.AreaCalculatorLib.Models.Shapes;

namespace ShapesAreaApp.UnitTests
{
    public class AreaCalculatorLibUnitTest
    {
        private const double Tolerance = 0.001;

        private ShapesFactory _shapesFactory;

        [SetUp]
        public void Setup()
        {
            _shapesFactory = new ShapesFactory(Tolerance);
        }

        [Test]
        public void ShouldThrowExceptionShapeIsNotTriangle()
        {
            Assert.Throws<ShapeIsNotTriangleException>(
                () => _shapesFactory.CreateTriangle(1, 2, 5));
        }

        [Test]
        public void ShouldReturnRightTriangle()
        {
            var triangle = _shapesFactory.CreateTriangle(3, 4, 5);
            Assert.IsInstanceOf<RightTriangle>(triangle);
        }

        [Test]
        public void ShouldReturnCorrectGaussTriangleArea()
        {
            var points = new[]
            {
                new Point(2, 1),
                new Point(4, 5),
                new Point(7, 8) 
            };
            var triangle = _shapesFactory.CreateShape(points);
            var area = triangle.GetArea();

            Assert.AreEqual(3, area);
        }

        [Test]
        public void ShouldReturnTheSameArea()
        {
            var triangle = new Triangle(3, 4, 5, Tolerance);
            var rightTriangle = new RightTriangle(3, 4, 5, Tolerance);
            
            Assert.AreEqual(
                rightTriangle.GetArea(), 
                triangle.GetArea(), 
                Tolerance);
        }

        [Test]
        public void ShouldThrowShapePointsRequiredException()
        {
            var points = new[]
            {
                new Point(2, 1),
                new Point(4, 5)
            };

            Assert.Throws<ShapePointsRequiredException>(() =>
                _shapesFactory.CreateShape(points));
        }

        [Test]
        public void ShouldThrowZeroOrNegativeRadiusException()
        {
            Assert.Throws<ZeroOrNegativeWidthException>(
                () => _shapesFactory.CreateCircle(0));
        }
    }
}