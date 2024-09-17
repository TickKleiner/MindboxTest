using FiguresArea.Common;
using FiguresArea.Exceptions;

namespace FiguresArea
{
    public sealed class Triangle : IFigure
    {
        public double SideA { get; }
        public double SideB { get; }
        public double SideC { get; }

        public double Area { get; }

        public bool RightAngled { get; }

        public Triangle(double sideA, double sideB, double sideC)
        {
            if (!IsValidTriangle(sideA, sideB, sideC))
            {
                throw new FigureInvalidException("Triangle is invalid");
            }

            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
            Area = GetArea();
            RightAngled = IsRightAngled();
        }

        private double GetArea()
        {
            //Формула Герона
            double s = (SideA + SideB + SideC) / 2.0;
            return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
        }

        private bool IsRightAngled()
        {
            //Обратная теорема Пифагора
            var sides = new[] { SideA, SideB, SideC }.OrderBy(side => side).ToArray();
            double a = sides[0], b = sides[1], c = sides[2];
            return Math.Abs(c * c - (a * a + b * b)) < double.Epsilon;
        }

        private bool IsValidTriangle(double a, double b, double c)
        {
            //Существует ли треугольник
            return a > 0 && b > 0 && c > 0 &&
                   a + b > c &&
                   a + c > b &&
                   b + c > a;
        }

        public override bool Equals(object? obj)
        {
            var triangle = obj as Triangle;
            if (triangle == null)
            {
                return false;
            }
            return triangle.SideA.Equals10DigitPrecision(SideA) &&
                triangle.SideB.Equals10DigitPrecision(SideB) &&
                triangle.SideC.Equals10DigitPrecision(SideC) &&
                triangle.Area.Equals10DigitPrecision(Area) &&
                triangle.RightAngled == RightAngled;
        }

        public override int GetHashCode()
        {
            return (int)SideA ^
                (int)SideB ^
                (int)SideC ^
                (int)Area ^
                (RightAngled ? 1 : 0);
        }
    }
}
