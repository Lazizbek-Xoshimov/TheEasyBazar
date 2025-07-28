namespace TheEasyBazar.Service.Exceptions;

public class CustomException : Exception
{
    public int StatusCode { get; }

    public CustomException(int statusCode, string message) : base(message)
    {
        this.StatusCode = statusCode;
    }
}
