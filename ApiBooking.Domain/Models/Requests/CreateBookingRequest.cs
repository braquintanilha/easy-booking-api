

using System.ComponentModel.DataAnnotations;

namespace ApiBooking.Domain.Models.Requests;

public class CreateBookingRequest
{
    [Required]
    public DateTime CheckInDt { get; set; }

    [Required]
    public DateTime CheckOutDt { get; set; }

    [Required]
    public int NumberOfGuests { get; set; }

    [Required]
    public decimal TotalPrice { get; set; }

    [Required]
    public int HotelId { get; set; }

    [Required]
    public int UserId { get; set; }
}
