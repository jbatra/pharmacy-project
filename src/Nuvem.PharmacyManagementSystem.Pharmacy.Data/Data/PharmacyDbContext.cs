using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Nuvem.PharmacyManagementSystem.Pharmacy.Data.Data;
public partial class PharmacyDbContext : DbContext
{   
    public string connString {get; set;}
    public PharmacyDbContext()
    {}

    public PharmacyDbContext(DbContextOptions<PharmacyDbContext> options)
        : base(options)
    {}

    public virtual DbSet<EFEntities.Pharmacy> Pharmacies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(connString);
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EFEntities.Pharmacy>(entity =>
        {
            entity.HasKey(e => e.PharmacyId).HasName("PK_dbo.Pharmacy");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

