using Microsoft.EntityFrameworkCore;

namespace Nuvem.PharmacyManagementSystem.Pharmacy.Data.Data
{   
public partial class PharmacyDbContext : DbContext
{   
    public PharmacyDbContext()
    {}

    public PharmacyDbContext(DbContextOptions<PharmacyDbContext> options)
        : base(options)
    {}

    public virtual DbSet<EFEntities.Pharmacy> Pharmacies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //TODO: The service configrattion in Pgram and/or factory class not configuring the DbContext...
         if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-EPGKLH7\SQLEXPRESS_2022;Initial Catalog=PharmacyManagementStore;User ID=jodi;Password=dallas;TrustServerCertificate=True;");
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
}
