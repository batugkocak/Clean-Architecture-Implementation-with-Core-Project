using Application.Features.Brands.Queries.GetList;
using Application.Features.Models.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Models.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Model, GetListModelDto>().ReverseMap();
        CreateMap<Paginate<Model>, GetListResponse<GetListModelDto>>().ReverseMap();
    }
} 
