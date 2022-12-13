namespace ProjectLibrary.exceptions;

public class NegativeLengthException : Exception
{
    public NegativeLengthException()
    {
    }

    public NegativeLengthException(string message)
        : base(message)
    {
    }

    public NegativeLengthException(string message, Exception inner)
        : base(message, inner)
    {
    }
}