using Microsoft.EntityFrameworkCore;
using PharmacyEntity = Nuvem.PharmacyManagementSystem.Pharmacy.Data.DatabaseContext.EFEntities.Pharmacy;

namespace Nuvem.PharmacyManagementSystem.Pharmacy.Data.DatabaseContext;
public partial class PharmacyDbContext : DbContext, IPharmacyDbContext

{   
    public DbContext Instance => this;
    public string? connString {get; set;}
    public PharmacyDbContext()
    {}

    public PharmacyDbContext(DbContextOptions<PharmacyDbContext> options)
        : base(options)
    {}

    public virtual DbSet<PharmacyEntity> Pharmacies { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(connString);
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PharmacyEntity>(entity =>
        {
            entity.HasKey(e => e.PharmacyId).HasName("PK_dbo.Pharmacy");
        });

        OnModelCreatingPartial(modelBuilder);
    }
    
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public Task<int> SaveChangesAsync()
    {
        return base.SaveChangesAsync();
    }
}

