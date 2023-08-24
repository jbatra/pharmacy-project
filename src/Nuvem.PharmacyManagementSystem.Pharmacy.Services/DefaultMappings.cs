using AutoMapper;
using Nuvem.PharmacyManagementSystem.Pharmacy.Services.Models;

namespace Nuvem.PharmacyManagementSystem.Pharmacy.Services;
    public class DefaultMappings : Profile
    {
        public DefaultMappings()
        {
            CreateMap<Data.EFEntities.Pharmacy, PharmacyModel>().ReverseMap();
        }
    }