using System;
using AutoMapper;
using Web.Shared.DTO;
using Web.Shared.Entities;
using Web.Shared.ValueObjects;

namespace Web.Server.Utility
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Contact, ContactDetailDTO>()
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.Address.State))
                .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.Address.ZipCode))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Address.Country))
                .ForMember(dest => dest.AddressId, opt => opt.MapFrom(src => src.Address.AddressId));

            CreateMap<ContactDetailDTO, Contact>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => MapAddress(src)));
        }

        private Address MapAddress(ContactDetailDTO src)
        {
            return new Address
            {
                Street = src.Street,
                City = src.City,
                State = src.State,
                ZipCode = src.ZipCode,
                Country = src.Country,
                AddressId = src.AddressId // Ensure this ID is properly handled (generated or provided)
            };
        }
    }
}

