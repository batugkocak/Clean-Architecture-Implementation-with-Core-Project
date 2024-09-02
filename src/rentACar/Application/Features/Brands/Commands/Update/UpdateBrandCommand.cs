using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.Brands.Commands.Update;

public class UpdateBrandCommand : IRequest<UpdatedBrandResponse>, ICacheRemoverRequest
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    
    public string? CacheKey { get; }
    public bool BypassCache { get; }
    public string? CacheGroupKey => "GetBrands";
    
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, UpdatedBrandResponse>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        
        public UpdateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        
        public async Task<UpdatedBrandResponse> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetAsync(b => b.Id == request.Id, cancellationToken: cancellationToken);

            brand = _mapper.Map(request, brand);

            await _brandRepository.UpdateAsync(brand);
            
            var response = _mapper.Map<UpdatedBrandResponse>(brand);
            
            return response;
        }
    }


    
}