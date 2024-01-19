using ApiBooking.Domain.Entities;
using ApiBooking.Repository.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ApiBooking.Repository.Contexts;

public class EasyBookingContext : DbContext
{

    public EasyBookingContext(DbContextOptions<EasyBookingContext> options) 
        : base(options)
    {
    }

    public DbSet<Booking> Bookings { get; set; } = default!;
    public DbSet<Hotel> Hotels { get; set; } = default!;
    public DbSet<User> Users { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BookingMapping());
        modelBuilder.ApplyConfiguration(new HotelMapping());
        modelBuilder.ApplyConfiguration(new UserMapping());
    }
}
