using ApiBooking.Domain;
using ApiBooking.Domain.Exceptions.Filters;
using ApiBooking.Domain.Models.Requests;
using ApiBooking.Domain.Repositories;
using ApiBooking.Domain.Services;
using ApiBooking.Domain.Validators;
using ApiBooking.Repository.Contexts;
using ApiBooking.Repository.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace ApiBooking.Api;

public class Startup
{
    private const string DbName = "EasyBooking";
    private const string AppName = "API Easy Booking";
    private const string AppVersion = "v1";

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers(options =>
        {
            options.Filters.Add<CustomExceptionFilter>();
        })
        .ConfigureApiBehaviorOptions(options => {
        options.SuppressModelStateInvalidFilter = true;
        });

        services.AddDbContext<EasyBookingContext>(options =>
        {
            options.UseSqlServer(Configuration.GetConnectionString(DbName));
        });

        services.AddScoped<IBookingService, BookingService>();
        services.AddScoped<IBookingRepository, BookingRepository>();
        services.AddScoped<IHotelRepository, HotelRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IValidator<CreateBookingRequest>, CreateBookingRequestValidator>();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc(AppVersion, new OpenApiInfo { Title = AppName, Version = AppVersion });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
            app.UseDeveloperExceptionPage();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            _ = endpoints.MapControllers();
        });

        app.Run(async (context) =>
        {
            context.Response.Redirect("/swagger");
            await Task.CompletedTask;
        });

    }
}
