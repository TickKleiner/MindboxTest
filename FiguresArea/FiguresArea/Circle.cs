using FiguresArea.Common;
using FiguresArea.Exceptions;

namespace FiguresArea
{
    public sealed class Circle : IFigure
    {
        public double Radius { get; }

        public double Area { get; }

        public Circle(double radius)
        {
            if (radius < 0)
            {
                throw new FigureInvalidException(
                    "Radius can't be negative", nameof(Radius));
            }
            Radius = radius;
            Area = Math.PI * Radius * Radius;
        }

        public override bool Equals(object? obj)
        {
            var circle = obj as Circle;
            if (circle == null)
            {
                return false;
            }
            return circle.Radius.Equals10DigitPrecision(Radius) &&
                circle.Area.Equals10DigitPrecision(Area);
        }

        public override int GetHashCode()
        {
            return (int)Radius ^ (int)Area;
        }
    }
}
