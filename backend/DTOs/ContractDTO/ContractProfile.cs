using AutoMapper;
using Backend.Models;

namespace Backend.DTOs.ContractDTO
{
    public class ContractProfile : Profile
    {
        public ContractProfile()
        {
            CreateMap<CreateContractDTO, Contract>();
            CreateMap<UpdateContractDTO, Contract>();
        }
    }
}
