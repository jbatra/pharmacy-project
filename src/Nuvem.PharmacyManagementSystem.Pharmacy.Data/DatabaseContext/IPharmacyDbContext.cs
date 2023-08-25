using Microsoft.EntityFrameworkCore;
using PharmacyEntity = Nuvem.PharmacyManagementSystem.Pharmacy.Data.DatabaseContext.EFEntities.Pharmacy;


namespace Nuvem.PharmacyManagementSystem.Pharmacy.Data.DatabaseContext;
public interface IPharmacyDbContext : IDisposable
{   
    DbSet<PharmacyEntity> Pharmacies { get; set; }    
    Task<int> SaveChangesAsync();
    DbContext Instance{get;}
    string? connString {get; set;}
}

