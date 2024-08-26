using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Brands.Queries.GetById;

public class GetByIdBrandQuery : IRequest<GetByIdBrandResponse>
{
    public Guid Id { get; set; }
    
    public class GetByIdBrandRequestHandler : IRequestHandler<GetByIdBrandQuery>
    {
        
    }
    private readonly IMapper _mapper;
    private readonly IBrandRepository _brandRepository;
    
    public GetByIdBrandQuery(IMapper mapper, IBrandRepository brandRepository)
    {
        _mapper = mapper;
        _brandRepository = brandRepository;
    }

   
}