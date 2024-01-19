using ApiBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiBooking.Repository.Mappings;

public class HotelMapping : IEntityTypeConfiguration<Hotel>
{
    public void Configure(EntityTypeBuilder<Hotel> builder)
    {
        builder.ToTable("Hotel");

        builder.HasKey(h => h.Id);

        builder.Property(h => h.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(h => h.Name)
            .HasColumnName("Name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(h => h.TotalRooms)
            .HasColumnName("TotalRooms")
            .IsRequired();

        builder.Property(h => h.AvailableRooms)
            .HasColumnName("AvailableRooms")
            .IsRequired();
    }
}
