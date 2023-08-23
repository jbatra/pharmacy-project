using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Nuvem.PharmacyManagementSystem.Pharmacy.Data.Data;

namespace Nuvem.PharmacyManagementSystem.Pharmacy.Data;

    public interface IPharmacyRepository
    {
        Task<List<EFEntities.Pharmacy>> GetAllAsync();
        Task<EFEntities.Pharmacy?> GetPharmacyByIdAsync(int id);
        Task<EFEntities.Pharmacy?> UpdatePharmacyAsync(EFEntities.Pharmacy pharmacy);      
    }
    public class PharmacyRepository : IPharmacyRepository
    {
        private readonly PharmacyDbContext _dbContext;
        private readonly AppSettingsConfiguraion _appConfig;
        
        public PharmacyRepository(AppSettingsConfiguraion appConfig)
        {
            _dbContext = new PharmacyDbContext();  
            _appConfig = appConfig;
            _dbContext.connString = _appConfig.EFConnectionString;
        }        

        public async Task<List<EFEntities.Pharmacy>> GetAllAsync()
        {
            return await Task.FromResult( _dbContext.Pharmacies.ToList());
        }


        public Task<EFEntities.Pharmacy?> GetPharmacyByIdAsync(int id)
        {
            return _dbContext.Pharmacies.FirstOrDefaultAsync(x => x.PharmacyId == id);
        }

        public async Task<EFEntities.Pharmacy?> UpdatePharmacyAsync(EFEntities.Pharmacy pharmacy)
        {
            var existingPharmacy = await GetPharmacyByIdAsync(pharmacy.PharmacyId);
            if (existingPharmacy is null) return null;
            pharmacy.UpdatedDate = DateTime.Now;

            _dbContext.Pharmacies.Attach(existingPharmacy);

            var entry = _dbContext.Entry(existingPharmacy);
            entry.CurrentValues.SetValues(pharmacy);

            entry.Property("PharmacyId").IsModified = false;
            entry.Property("CreatedDate").IsModified = false;   

            await _dbContext.SaveChangesAsync();  
            return existingPharmacy; 
        }
    }
