using Application.Features.Brands.Commands.Create;
using Domain.Entities;
using AutoMapper;

namespace Application.Features.Brands.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Brand, CreateBrandCommand>().ReverseMap();
        CreateMap<Brand, CreateBrandResponse>().ReverseMap();
    }
} 