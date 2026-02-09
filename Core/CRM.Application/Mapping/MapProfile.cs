using AutoMapper;
using CRM.Application.DTOs.AccountDTOs;
using CRM.Application.DTOs.ActivityDTOs;
using CRM.Application.DTOs.AttendeeDTOs;
using CRM.Application.DTOs.CategoryDTOs;
using CRM.Application.DTOs.ContactDTOs;
using CRM.Application.DTOs.DealTypeDTOs;
using CRM.Application.DTOs.LeadDTOs;
using CRM.Application.DTOs.StageDTOs;
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

            CreateMap<DealType, DealTypeDTO>().ReverseMap();
            CreateMap<CreateDealTypeDTO, DealType>().ReverseMap();
            CreateMap<UpdateDealTypeDTO, DealType>().ReverseMap();

            CreateMap<Stage, StageDTO>().ReverseMap();
            CreateMap<CreateStageDTO, Stage>().ReverseMap();
            CreateMap<UpdateStageDTO, Stage>().ReverseMap();

            CreateMap<Activity, ActivityDTO>().ReverseMap()
                .ForMember(prop => prop.Attendees, opt => opt.MapFrom(src => src.Attendees));
            CreateMap<CreateActivityDTO, Activity>().ReverseMap()
                .ForMember(prop => prop.Attendees, opt => opt.MapFrom(src => src.Attendees));
            CreateMap<UpdateActivityDTO, Activity>().ReverseMap();

            CreateMap<Attendee, AttendeeDTO>().ReverseMap();

        }



    }
}
