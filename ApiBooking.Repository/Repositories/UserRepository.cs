using ApiBooking.Domain.Repositories;
using ApiBooking.Repository.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ApiBooking.Repository.Repositories;

public class UserRepository : IUserRepository
{
    private readonly EasyBookingContext _context;

    public UserRepository(EasyBookingContext context)
    {
        _context = context;
    }

    public Task<bool> IsUserIdValid(int userId)
    {
        return _context.Hotels.AnyAsync(x => x.Id == userId);
    }
}
