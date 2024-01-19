using ApiBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiBooking.Repository.Mappings;

public class BookingMapping : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable("Booking");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .HasColumnName("Id");

        builder.Property(b => b.CheckInDt)
            .HasColumnName("CheckInDt")
            .IsRequired();

        builder.Property(b => b.CheckOutDt)
            .HasColumnName("CheckOutDt")
            .IsRequired();

        builder.Property(b => b.NumberOfGuests)
            .HasColumnName("NumberOfGuests")
            .IsRequired();

        builder.Property(b => b.TotalPrice)
            .HasColumnName("TotalPrice")
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(b => b.Status)
            .HasColumnName("StatusId")
            .HasColumnType("SMALLINT")
            .IsRequired();

        builder.Property(b => b.HotelId)
            .HasColumnName("HotelId")
            .IsRequired();

        builder.Property(b => b.UserId)
            .HasColumnName("UserId")
            .IsRequired();

        builder.HasOne(b => b.Hotel)
            .WithMany()
            .HasForeignKey(b => b.HotelId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(b => b.User)
            .WithMany()
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
