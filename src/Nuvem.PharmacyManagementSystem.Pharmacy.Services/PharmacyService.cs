using AutoMapper;
using PharmacyEntity = Nuvem.PharmacyManagementSystem.Pharmacy.Data.DatabaseContext.EFEntities.Pharmacy;
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
        List<PharmacyEntity> pharmacyList = await _pharmacyRepository.GetAllPharmaciesAsync();
        
        if(pharmacyList is null) return null;
        List<PharmacyModel> resultList = new();
        foreach(var pharmacy in pharmacyList)
        {
            var ph = MappingHelper<PharmacyModel,PharmacyEntity>.Map(pharmacy);
            resultList.Add(ph);
        }
        return resultList;
    } 
    public async Task<PharmacyModel?> GetPharmacyByIdAsync(int id)
    {
        PharmacyEntity? pharmacy = await _pharmacyRepository.GetPharmacyByIdAsync(id);
        
        if(pharmacy is null) return null;

        return  MappingHelper<PharmacyModel,PharmacyEntity>.Map(pharmacy);
    }

    public async Task<PharmacyModel?> UpdatePharmacyAsync(PharmacyModel pharmacy)
    {
        var pharmacyToBeUpdated = MappingHelper<PharmacyEntity,PharmacyModel>.Map(pharmacy);

        var updatedPharmacy = await _pharmacyRepository.UpdatePharmacyAsync(pharmacyToBeUpdated);//(_mapper.Map<PharmacyModel,PharmacyEntity>(pharmacy));
        
        if(updatedPharmacy is null) return null;

        return  MappingHelper<PharmacyModel,PharmacyEntity>.Map(updatedPharmacy);
    }
}