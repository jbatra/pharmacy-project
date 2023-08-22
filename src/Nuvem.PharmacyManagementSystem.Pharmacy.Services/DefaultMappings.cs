using AutoMapper;
using Nuvem.PharmacyManagementSystem.Pharmacy.Data.EFEntities;


namespace Nuvem.PharmacyManagementSystem.Pharmacy.Services
{
    public class DefaultMappings : Profile
    {
        public DefaultMappings()
        {
            CreateMap<Data.EFEntities.Pharmacy, PharmacyModel>();
            CreateMap<PharmacyModel, Data.EFEntities.Pharmacy>();
            //.ReverseMap();
           // CreateMap<IEnumerable<Data.EFEntities.Pharmacy>, IEnumerable<PharmacyModel>>().ReverseMap();
           // CreateMap<List<Data.EFEntities.Pharmacy>, List<PharmacyModel>>().ReverseMap();            
                    
        }
    }
    
}