using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queries.GetById;
using Application.Features.Brands.Queries.GetList;
using Domain.Entities;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;

namespace Application.Features.Brands.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Brand, CreateBrandCommand>().ReverseMap();
        CreateMap<Brand, CreateBrandResponse>().ReverseMap();

        CreateMap<Brand, GetListBrandDto>().ReverseMap();
        CreateMap<Paginate<Brand>, GetListResponse<GetListBrandDto>>().ReverseMap();
        
        CreateMap<Brand, GetByIdBrandResponse>().ReverseMap();
        CreateMap<Brand, GetByIdBrandQuery>().ReverseMap();

        CreateMap<Brand, UpdatedBrandResponse>().ReverseMap();
        CreateMap<Brand, UpdateBrandCommand>().ReverseMap();
    }
} 