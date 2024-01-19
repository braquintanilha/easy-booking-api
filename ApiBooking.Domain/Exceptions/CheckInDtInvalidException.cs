namespace ApiBooking.Domain.Exceptions;

public class CheckInDtInvalidException : Exception
{
    public CheckInDtInvalidException() : base("CheckInDt cannot be in the past.")
    {
    }

    public CheckInDtInvalidException(string message) : base(message)
    {
    }

    public CheckInDtInvalidException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
