using Microsoft.EntityFrameworkCore;
using service.transport.common.Entity;

namespace service.transport.data;

public class TransportDbContext : DbContext
{
    public DbSet<TransportationOption> TransportationOptions { get; set; }

    public TransportDbContext(DbContextOptions<TransportDbContext> options)
        : base(options)
    {
    }
}

