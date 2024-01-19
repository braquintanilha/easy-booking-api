using ApiBooking.Domain.Entities;
using ApiBooking.Domain.Enums;

namespace ApiBooking.Domain.Models.Responses;

public class BookingResponse
{
    public BookingResponse(Booking booking)
    {
        Id = booking.Id;
        CheckInDt = booking.CheckInDt;
        CheckOutDt = booking.CheckOutDt;
        NumberOfGuests = booking.NumberOfGuests;
        TotalPrice = booking.TotalPrice;
        Status = booking.Status;
        Hotel = booking.Hotel;
        User = booking.User;
    }

    public int Id { get; private set; }
    public DateTime CheckInDt { get; private set; }
    public DateTime CheckOutDt { get; private set; }
    public int NumberOfGuests { get; private set; }
    public decimal TotalPrice { get; private set; }
    public BookingStatus Status { get; private set; }
    public Hotel Hotel { get; private set; }
    public User User { get; private set; }

    public static explicit operator BookingResponse(Booking booking)
    {
        return new BookingResponse(booking);
    }
}
