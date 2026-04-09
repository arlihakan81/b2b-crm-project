using AutoMapper;
using CRM.Application.Requests.Accounts;
using CRM.Application.Requests.Contacts;
using CRM.Application.Requests.Deals;
using CRM.Application.Requests.Products;
using CRM.Application.Responses.Accounts;
using CRM.Application.Responses.Contacts;
using CRM.Application.Responses.Deals;
using CRM.Application.Responses.Products;
using CRM.Domain.Entities;
using Microsoft.Extensions.Options;

namespace CRM.Application.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Account, AccountResponse>();
            CreateMap<Account, AccountDetailResponse>().ForMember(des => des.Contacts, opt => opt.MapFrom(src => src.Contacts));
            CreateMap<CreateAccountRequest, Account>();
            CreateMap<UpdateAccountRequest, Account>();

            CreateMap<Contact, ContactResponse>().ForMember(des => des.Account, opt => opt.MapFrom(src => src.Account));
            CreateMap<Contact, ContactDetailResponse>().ForMember(des => des.Account, opt => opt.MapFrom(src => src.Account));
            CreateMap<CreateContactRequest, Contact>();
            CreateMap<UpdateContactRequest, Contact>();

            CreateMap<Deal, DealResponse>().ForMember(des => des.Contact, opt => opt.MapFrom(src => src.Contact));
            CreateMap<CreateDealRequest, Deal>();
            CreateMap<UpdateDealRequest, Deal>();

            CreateMap<Product, ProductResponse>();
            CreateMap<CreateProductRequest, Product>();


        }
    }
}
