using FiguresArea.Exceptions;

namespace FiguresArea.Tests
{
    [TestFixture]
    public class FiguresAreaTests
    {
        [Test]
        public void CircleAreaTest()
        {
            var circle = new Circle(10);
            Assert.That(circle.Area, Is.EqualTo(Math.PI * 100).Within(1e-10));
        }

        [Test]
        public void TriangleAreaTest()
        {
            var triangle = new Triangle(3, 4, 5);
            Assert.That(triangle.Area, Is.EqualTo(6).Within(1e-10));
        }

        [Test]
        public void TriangleIsRightAngledTest()
        {
            var triangle = new Triangle(3, 4, 5);
            Assert.That(triangle.RightAngled, Is.True);
        }

        [Test]
        public void TriangleIsNotRightAngledTest()
        {
            var triangle = new Triangle(5, 5, 5);
            Assert.That(triangle.RightAngled, Is.False);
        }

        [Test]
        public void InvalidCircleTest()
        {
            Assert.Throws<FigureInvalidException>(() => new Circle(-1));
        }

        [Test]
        public void InvalidTriangleTest()
        {
            Assert.Throws<FigureInvalidException>(() => new Triangle(1, 2, 3));
        }
    }
}