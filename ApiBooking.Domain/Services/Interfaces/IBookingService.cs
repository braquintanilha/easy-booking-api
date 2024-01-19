using ApiBooking.Domain.Entities;

namespace ApiBooking.Domain;

public interface IBookingService
{
    Task<List<Booking>> GetAllBookings();

    Task<Booking?> GetBooking(int id);

    Task<Booking?> ConfirmBooking(Booking booking);

    Task<Booking?> CancelBooking(Booking booking);

    Task<Booking> CreateBooking(Booking booking);

    Task<Booking?> DeleteBooking(int id);
}
