using System.Text.Json.Serialization;
using ApiBooking.Domain.Enums;
using ApiBooking.Domain.Models.Requests;

namespace ApiBooking.Domain.Entities;

public class Booking
{
    public Booking()
    {
    }

    public Booking(CreateBookingRequest request)
    {
        CheckInDt = request.CheckInDt;
        CheckOutDt = request.CheckOutDt;
        NumberOfGuests = request.NumberOfGuests;
        TotalPrice = request.TotalPrice;
        HotelId = request.HotelId;
        UserId = request.UserId;
    }

    public int Id { get; private set; }
    public DateTime CheckInDt { get; private set; }
    public DateTime CheckOutDt { get; private set; }
    public int NumberOfGuests { get; private set; }
    public decimal TotalPrice { get; private set; }
    public BookingStatus Status { get; private set; }
    public int HotelId { get; private set; }
    public int UserId { get; private set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Hotel Hotel { get; private set; } = default!;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public User User { get; private set; } = default!;

    public void SetStatus(BookingStatus status)
    {
        Status = status;
    }
}
