using AutoMapper;
using CRM.Application.DTOs.AccountDTOs;
using CRM.Application.DTOs.ContactDTOs;
using CRM.Domain.Entities;

namespace CRM.Application.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Account, AccountDTO>()
                .ForMember(prop => prop.Contacts, opt => opt.MapFrom(src => src.Contacts))
                .ReverseMap();
            CreateMap<CreateAccountDTO, Account>().ReverseMap();
            CreateMap<UpdateAccountDTO, Account>().ReverseMap();

            CreateMap<Contact, ContactDTO>()
                .ForMember(prop => prop.Account, opt => opt.MapFrom(src => src.Account))
                .ReverseMap();
            CreateMap<CreateContactDTO, Contact>().ReverseMap();
            CreateMap<UpdateContactDTO, Contact>().ReverseMap();

        }



    }
}
