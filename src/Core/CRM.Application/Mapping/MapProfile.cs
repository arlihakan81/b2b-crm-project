using AutoMapper;
using CRM.Application.Requests.Accounts;
using CRM.Application.Requests.Activities;
using CRM.Application.Requests.Contacts;
using CRM.Application.Requests.Deals;
using CRM.Application.Requests.Leads;
using CRM.Application.Requests.Products;
using CRM.Application.Requests.QuoteItems;
using CRM.Application.Requests.Quotes;
using CRM.Application.Responses.Accounts;
using CRM.Application.Responses.Activities;
using CRM.Application.Responses.Contacts;
using CRM.Application.Responses.Deals;
using CRM.Application.Responses.Leads;
using CRM.Application.Responses.Products;
using CRM.Application.Responses.QuoteItems;
using CRM.Application.Responses.Quotes;
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
            CreateMap<UpdateProductRequest, Product>();

            CreateMap<Lead, LeadResponse>();
            CreateMap<Lead, LeadDetailResponse>().ForMember(des => des.Contact, opt => opt.MapFrom(src => src.Contact));
            CreateMap<CreateLeadRequest, Lead>();
            CreateMap<UpdateLeadRequest, Lead>();

            CreateMap<Quote, QuoteResponse>().ForMember(des => des.Items, opt => opt.MapFrom(src => src.Items)).ForMember(des => des.Deal, opt => opt.MapFrom(src => src.Deal));
            CreateMap<CreateQuoteRequest, Quote>();
            CreateMap<UpdateQuoteRequest, Quote>();

            CreateMap<QuoteItem, QuoteItemResponse>().ForMember(des => des.Product, opt => opt.MapFrom(src => src.Product));
            CreateMap<CreateQuoteItemRequest, QuoteItem>();
            CreateMap<UpdateQuoteItemRequest, QuoteItem>();

            CreateMap<Activity, ActivityResponse>();
            CreateMap<CreateActivityRequest, Activity>();
            CreateMap<UpdateActivityRequest, Activity>();

        }
    }
}
