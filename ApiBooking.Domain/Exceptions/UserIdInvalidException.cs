namespace ApiBooking.Domain.Exceptions;

public class UserIdInvalidException : Exception
{
    public UserIdInvalidException() : base("UserId does not exist.")
    {
    }

    public UserIdInvalidException(string message) : base(message)
    {
    }

    public UserIdInvalidException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
