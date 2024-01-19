using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ApiBooking.Repository.Contexts;

// TODO: remover essa classe e as migrations após finalizar o design do BD
public class EasyBookingContextFactory : IDesignTimeDbContextFactory<EasyBookingContext>
{
    public EasyBookingContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EasyBookingContext>();
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=EasyBooking;User ID=sa;Password=s3nh4s3cr3t4!!;TrustServerCertificate=true;");

        return new EasyBookingContext(optionsBuilder.Options);
    }
}
