namespace ApiBooking.Domain.Exceptions;

public class HotelIdInvalidException : Exception
{
    public HotelIdInvalidException() : base("HotelId does not exist.")
    {
    }

    public HotelIdInvalidException(string message) : base(message)
    {
    }

    public HotelIdInvalidException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
