using ApiBooking.Domain.Entities;
using ApiBooking.Domain.Repositories;
using ApiBooking.Repository.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ApiBooking.Repository.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly EasyBookingContext _context;

    public BookingRepository(EasyBookingContext context)
    {
        _context = context;
    }

    public async Task<List<Booking>> GetAllBookings()
    {
        return await _context.Bookings
            .AsNoTracking()
            .Include(booking => booking.Hotel)
            .Include(booking => booking.User)
            .ToListAsync();
    }

    public async Task<Booking?> GetBooking(int id)
    {
        return await _context.Bookings
            .Where(x => x.Id == id)
            .Include(booking => booking.Hotel)
            .Include(booking => booking.User)
            .FirstOrDefaultAsync();
    }

    public async Task<Booking> CreateBooking(Booking booking)
    {
        var result = await _context.Bookings
            .AddAsync(booking);
        
        await _context.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<Booking?> DeleteBooking(int id)
    {
        var booking = await _context.Bookings.FindAsync(id);
        _context.Bookings.Remove(booking!);
        await _context.SaveChangesAsync();

        return booking;
    }

    public async Task<Booking?> UpdateBooking(Booking booking)
    {
        _context.Attach(booking).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
            return booking;
        }
        catch (DbUpdateConcurrencyException)
        {
            return null;
        }
    }
}
