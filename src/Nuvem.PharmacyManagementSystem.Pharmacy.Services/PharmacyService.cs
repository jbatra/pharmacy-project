using AutoMapper;
using Nuvem.PharmacyManagementSystem.Pharmacy.Data;
using Nuvem.PharmacyManagementSystem.Pharmacy.Services.Models;

namespace Nuvem.PharmacyManagementSystem.Pharmacy.Services;
public interface IPharmacyService
{
    Task<List<PharmacyModel>> GetAllAsync();
    Task<PharmacyModel?> GetPharmacyByIdAsync(int id);
    Task<PharmacyModel?> UpdatePharmacyAsync(PharmacyModel pharmacy);
}

public class PharmacyService : IPharmacyService
{
    private readonly IPharmacyRepository _pharmacyRepository;
    private readonly IMapper _mapper;

    public PharmacyService(IPharmacyRepository pharmacyRepository, IMapper mapper)
    {
        _pharmacyRepository = pharmacyRepository;
        _mapper = mapper;
    }

    public async Task<List<PharmacyModel>> GetAllAsync()
    {     
        List<Data.EFEntities.Pharmacy> pharmacyList = await _pharmacyRepository.GetAllAsync();
        return _mapper.Map<List<PharmacyModel>>(pharmacyList);
    } 
    public async Task<PharmacyModel?> GetPharmacyByIdAsync(int id)
    {
        Data.EFEntities.Pharmacy pharmacy = await _pharmacyRepository.GetPharmacyByIdAsync(id);
        
        if(pharmacy is null) return null;

        return _mapper.Map<Data.EFEntities.Pharmacy, PharmacyModel>(pharmacy);
    }

    public async Task<PharmacyModel?> UpdatePharmacyAsync(PharmacyModel pharmacy)
    {
        var updatedPharmacy = await _pharmacyRepository.UpdatePharmacyAsync(_mapper.Map<PharmacyModel,Data.EFEntities.Pharmacy>(pharmacy));
        
        if(updatedPharmacy is null) return null;

        return _mapper.Map<Data.EFEntities.Pharmacy, PharmacyModel>(updatedPharmacy);
    }
}