using AutoMapper;
using PharmacyEntity = Nuvem.PharmacyManagementSystem.Pharmacy.Data.DatabaseContext.EFEntities.Pharmacy;
using Nuvem.PharmacyManagementSystem.Pharmacy.Services.Models;

namespace Nuvem.PharmacyManagementSystem.Pharmacy.Services;
    public class DefaultMappings : Profile
    {
        public DefaultMappings()
        {
            CreateMap<PharmacyEntity, PharmacyModel>().ReverseMap();
        }
        
    }