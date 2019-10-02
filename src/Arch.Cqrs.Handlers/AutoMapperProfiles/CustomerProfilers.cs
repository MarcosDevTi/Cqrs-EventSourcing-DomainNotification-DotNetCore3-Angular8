using Arch.Cqrs.Client.Models.Customer;
using Arch.Cqrs.Client.Models.CustomerModels;
using Arch.Domain.Entities.ValueObjects;
using AutoMapper;

namespace Arch.Handlers.AutoMapperProfiles
{
    public class CustomerProfilers: Profile
    {
        public CustomerProfilers()
        {
            CreateMap<CreateCustomer, Domain.Entities.Customer>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src =>
                    new Name
                    {
                        FirstName = src.FirstName,
                        LastName = src.LastName
                    }))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new Address
                {
                    Number = src.Number,
                    Street = src.Street,
                    City = src.City,
                    Country = src.Country,
                    ZipCode = src.ZipCode
                }));

            CreateMap<Domain.Entities.Customer, CreateCustomer>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Name.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Name.LastName))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Address.Number))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Address.Country))
                .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.Address.ZipCode));

            CreateMap<Domain.Entities.Customer, CustomerItem>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address.AsString))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.FirstName + " " + src.Name.LastName));

            CreateMap<Domain.Entities.Customer, UpdateCustomer>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Name.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Name.LastName))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Address.Number))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Address.Country))
                .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.Address.ZipCode));
        }
    }
}
