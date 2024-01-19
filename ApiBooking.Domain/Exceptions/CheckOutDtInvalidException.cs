namespace ApiBooking.Domain.Exceptions;

public class CheckOutDtInvalidException : Exception
{
    public CheckOutDtInvalidException() : base("The booking must be at least 1 day.")
    {
    }

    public CheckOutDtInvalidException(string message) : base(message)
    {
    }

    public CheckOutDtInvalidException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
