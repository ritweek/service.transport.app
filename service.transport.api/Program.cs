using Microsoft.EntityFrameworkCore;
using service.transport.business;
using service.transport.data;

namespace service.transport.api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<TransportDbContext>(options =>
            options.UseInMemoryDatabase("InMemoryTransportDb"));
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        ConfigureServices(builder.Services);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
    private static void ConfigureServices(IServiceCollection services)
    {
        // Register your services and repositories here
        services.AddScoped<ITransportService, TransportService>();
        services.AddScoped<ITransportRepo, TransportRepo>();
        services.AddScoped<IBookingRepository, BookingRepository>();
        services.AddScoped<IBookingService, BookingService>();
    }


}

