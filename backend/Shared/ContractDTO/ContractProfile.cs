using AutoMapper;
using Entities.Models;

namespace Shared.ContractDTO
{
    public class ContractProfile : Profile
    {
        public ContractProfile()
        {
            CreateMap<Contract, ReadContractDTO>().ReverseMap();
            CreateMap<CreateContractDTO, Contract>();
            CreateMap<UpdateContractDTO, Contract>().ReverseMap();
        }
    }
}
