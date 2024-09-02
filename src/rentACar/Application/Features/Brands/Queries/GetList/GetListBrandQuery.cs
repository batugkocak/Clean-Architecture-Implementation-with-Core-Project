using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.Brands.Queries.GetList;

public class GetListBrandQuery : IRequest<GetListResponse<GetListBrandDto>>, ICacheableRequest
{
    public PageRequest PageRequest { get; set; }
    public string CacheKey => $"GetListBrandQuery({PageRequest.PageIndex},{PageRequest.PageSize})";

    public string? CacheGroupKey => $"GetBrands";

    public bool BypassCache { get; }

    public TimeSpan? SlidingExpiration { get; }
    
    public class GetListBrandHandler : IRequestHandler<GetListBrandQuery, GetListResponse<GetListBrandDto>>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        
        public GetListBrandHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }   
        
        public async Task<GetListResponse<GetListBrandDto>> Handle(GetListBrandQuery request, CancellationToken cancellationToken)
        {
           var paginate =  await _brandRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

           var response = _mapper.Map<GetListResponse<GetListBrandDto>>(paginate);

           return response;
        }
    }


}