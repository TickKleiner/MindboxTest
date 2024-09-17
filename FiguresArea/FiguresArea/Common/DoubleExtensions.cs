namespace FiguresArea.Common
{
    internal static class DoubleExtensions
    {
        const double _3 = 1e-3;
        const double _10 = 1e-10;

        public static bool Equals3DigitPrecision(this double left, double right)
        {
            return Math.Abs(left - right) < _3;
        }

        public static bool Equals10DigitPrecision(this double left, double right)
        {
            return Math.Abs(left - right) < _10;
        }

        public static bool EqualsEpsilonPrecision(this double left, double right)
        {
            return Math.Abs(left - right) < double.Epsilon;
        }
    }
}
