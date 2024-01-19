using ApiBooking.Domain.Entities;
using ApiBooking.Domain.Exceptions;
using ApiBooking.Domain.Repositories;

namespace ApiBooking.Domain.Services;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IHotelRepository _hotelRepository;
    private readonly IUserRepository _userRepository;

    public BookingService(IBookingRepository bookingRepository, IHotelRepository hotelRepository, IUserRepository userRepository)
    {
        _bookingRepository = bookingRepository;
        _hotelRepository = hotelRepository;
        _userRepository = userRepository;
    }

    public async Task<List<Booking>> GetAllBookings()
    {
        return await _bookingRepository.GetAllBookings();
    }

    public async Task<Booking?> GetBooking(int id)
    {
        return await _bookingRepository.GetBooking(id);
    }

    public async Task<Booking> CreateBooking(Booking booking)
    {
        ThrowIfCheckInDtIsInvalid(booking.CheckInDt);
        ThrowIfCheckOutDtIsInvalid(booking.CheckInDt, booking.CheckOutDt);
        await ThrowIfHotelIdIsInvalid(booking.HotelId);
        await ThrowIfUserIdIsInvalid(booking.UserId);

        booking.SetStatus(Enums.BookingStatus.Pending);
        return await _bookingRepository.CreateBooking(booking);
    }

    public async Task<Booking?> ConfirmBooking(Booking booking)
    {
        booking.SetStatus(Enums.BookingStatus.Confirmed);
        return await _bookingRepository.UpdateBooking(booking);
    }

    public async Task<Booking?> CancelBooking(Booking booking)
    {
        booking.SetStatus(Enums.BookingStatus.Cancelled);
        return await _bookingRepository.UpdateBooking(booking);
    }

    public async Task<Booking?> DeleteBooking(int id)
    {
        return await _bookingRepository.DeleteBooking(id);
    }

    private void ThrowIfCheckInDtIsInvalid(DateTime checkIn)
    {
        if (checkIn < DateTime.Now)
            throw new CheckInDtInvalidException();
    }

    private void ThrowIfCheckOutDtIsInvalid(DateTime checkIn, DateTime checkOut)
    {
        if (checkOut < checkIn.AddDays(1))
            throw new CheckOutDtInvalidException();
    }

    private async Task ThrowIfHotelIdIsInvalid(int hotelId)
    {
        var isValid = await _hotelRepository.IsHotelIdValid(hotelId);

        if (!isValid)
            throw new HotelIdInvalidException();
    }

    private async Task ThrowIfUserIdIsInvalid(int userId)
    {
        var isValid = await _userRepository.IsUserIdValid(userId);

        if (!isValid)
            throw new UserIdInvalidException();
    }
}
