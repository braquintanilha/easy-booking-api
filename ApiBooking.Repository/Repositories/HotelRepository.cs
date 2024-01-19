using ApiBooking.Domain.Repositories;
using ApiBooking.Repository.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ApiBooking.Repository.Repositories;

public class HotelRepository : IHotelRepository
{
    private readonly EasyBookingContext _context;

    public HotelRepository(EasyBookingContext context)
    {
        _context = context;
    }

    public Task<bool> IsHotelIdValid(int hotelId)
    {
        return _context.Hotels.AnyAsync(x => x.Id == hotelId);
    }
}
