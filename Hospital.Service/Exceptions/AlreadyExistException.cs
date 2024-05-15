namespace Hospital.Service.Exceptions;

public class AlreadyExistException : Exception
{
    public int StatusCode => 409;

    public AlreadyExistException(string message) : base(message) { }
}

 