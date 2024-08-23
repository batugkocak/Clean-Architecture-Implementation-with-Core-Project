using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.Create;

public class CreateBrandCommand : IRequest<CreateBrandResponse>
{
    public string Name { get; set; }

    public class CreateBrandHandler : IRequestHandler<CreateBrandCommand, CreateBrandResponse>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        public CreateBrandHandler(IBrandRepository brandRepository, IMapper mapper )
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        
        public async Task<CreateBrandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = _mapper.Map<Brand>(request);
            brand.Id = Guid.NewGuid();
            
            var result = await _brandRepository.AddAsync(brand);

            var response = _mapper.Map<CreateBrandResponse>(result);
            
            return response;
        }
    }       
}