using AutoMapper;
using CRM.Application.DTOs.AccountDTOs;
using CRM.Application.DTOs.CategoryDTOs;
using CRM.Application.DTOs.ContactDTOs;
using CRM.Application.DTOs.LeadDTOs;
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

            CreateMap<Lead, LeadDTO>().ReverseMap();
            CreateMap<CreateLeadDTO, Lead>().ReverseMap();
            CreateMap<UpdateLeadDTO, Lead>().ReverseMap();

            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<CreateCategoryDTO, Category>().ReverseMap();
            CreateMap<UpdateCategoryDTO, Category>().ReverseMap();

        }



    }
}
