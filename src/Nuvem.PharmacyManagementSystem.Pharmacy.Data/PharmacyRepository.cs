using Microsoft.EntityFrameworkCore;
using PharmacyEntity = Nuvem.PharmacyManagementSystem.Pharmacy.Data.DatabaseContext.EFEntities.Pharmacy;
using Nuvem.PharmacyManagementSystem.Pharmacy.Data.DatabaseContext;

namespace Nuvem.PharmacyManagementSystem.Pharmacy.Data;

    public interface IPharmacyRepository
    {
        Task<List<PharmacyEntity>> GetAllPharmaciesAsync();
        Task<PharmacyEntity?> GetPharmacyByIdAsync(int id);
        Task<PharmacyEntity?> UpdatePharmacyAsync(PharmacyEntity pharmacy);      
    }
    public class PharmacyRepository : IPharmacyRepository
    {
        private readonly IPharmacyDbContext _dbContext;
        private readonly AppSettingsConfiguraion _appConfig;
        
        public PharmacyRepository(IPharmacyDbContext dbContext, AppSettingsConfiguraion appConfig)
        {
            _dbContext = dbContext;  
            _appConfig = appConfig;
            _dbContext.connString = _appConfig.EFConnectionString;
        }        

        public async Task<List<PharmacyEntity>> GetAllPharmaciesAsync()
        {
            return await Task.FromResult( _dbContext.Pharmacies.ToList());
        }

        public Task<PharmacyEntity?> GetPharmacyByIdAsync(int id)
        {
            return _dbContext.Pharmacies.FirstOrDefaultAsync(x => x.PharmacyId == id);
        }

        public async Task<PharmacyEntity?> UpdatePharmacyAsync(PharmacyEntity pharmacy)
        {
            var existingPharmacy = await GetPharmacyByIdAsync(pharmacy.PharmacyId);
            if (existingPharmacy is null) return null;
            pharmacy.UpdatedDate = DateTime.Now;

            _dbContext.Pharmacies.Attach(existingPharmacy);

            var entry = _dbContext.Instance.Entry(existingPharmacy);
            entry.CurrentValues.SetValues(pharmacy);

            entry.Property("PharmacyId").IsModified = false;
            entry.Property("CreatedDate").IsModified = false;   

            await _dbContext.SaveChangesAsync();  
            return existingPharmacy; 
        }
    }
