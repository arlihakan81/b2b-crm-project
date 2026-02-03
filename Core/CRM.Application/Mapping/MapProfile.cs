using AutoMapper;
using CRM.Application.DTOs.AccountDTOs;
using CRM.Domain.Entities;

namespace CRM.Application.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Account, AccountDTO>().ReverseMap();
        }



    }
}
