using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.Create;

public class CreateBrandCommand : IRequest<CreateBrandResponse>, ITransactionalRequest, ICacheRemoverRequest
{
    public string Name { get; set; }
    
    
    public string? CacheKey { get; }
    public bool BypassCache { get; }
    public string? CacheGroupKey => "GetBrands";
    
    public class CreateBrandHandler : IRequestHandler<CreateBrandCommand, CreateBrandResponse>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        private readonly BrandBusinessRules _brandBusinessRules;    
        public CreateBrandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules )
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
            _brandBusinessRules = brandBusinessRules;
        }
        
        public async Task<CreateBrandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            await _brandBusinessRules.BrandNameDuplicatedWhenInserted(request.Name);
            
            var brand = _mapper.Map<Brand>(request);
            brand.Id = Guid.NewGuid();
            
            var result = await _brandRepository.AddAsync(brand);

            var response = _mapper.Map<CreateBrandResponse>(result);
            
            return response;
        }
    }

}