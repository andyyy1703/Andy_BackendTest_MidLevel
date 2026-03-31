using Microsoft.EntityFrameworkCore;

namespace backendTest.Context;

public class BackendTestContext(DbContextOptions<BackendTestContext> options) : DbContext(options)
{
    public DbSet<ACPDDto> MyOfficeAcpds { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ACPDDto>().ToTable("MyOffice_ACPD");
        modelBuilder.Entity<ACPDDto>().HasKey(e => e.AcpdSid);
    }
}
