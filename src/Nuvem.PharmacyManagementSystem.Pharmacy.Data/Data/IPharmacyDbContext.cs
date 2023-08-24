using Microsoft.EntityFrameworkCore;

namespace Nuvem.PharmacyManagementSystem.Pharmacy.Data.Data;
public interface IPharmacyDbContext : IDisposable
{   
    DbSet<EFEntities.Pharmacy> Pharmacies { get; set; }    
    Task<int> SaveChangesAsync();
    DbContext Instance{get;}
    string connString {get; set;}
}

