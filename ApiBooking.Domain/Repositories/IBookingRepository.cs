using ApiBooking.Domain.Entities;

namespace ApiBooking.Domain.Repositories;

public interface IBookingRepository
{
    Task<List<Booking>> GetAllBookings();

    Task<Booking?> GetBooking(int id);

    Task<Booking> CreateBooking(Booking booking);

    Task<Booking?> UpdateBooking(Booking booking);

    Task<Booking?> DeleteBooking(int id);
}
