namespace FiguresArea.Exceptions
{
    public class FigureInvalidException : ArgumentException
    {
        public FigureInvalidException(string message) : base(message) { }
        public FigureInvalidException(string message, string paramName) : base(message, paramName) { }
    }
}
