using MediatR;

namespace Application.Features.Brands.Commands.Create;

public class CreateBrandCommand : IRequest<CreateBrandResponse>
{
    public string Name { get; set; }

    public class CreateBrandHandler : IRequestHandler<CreateBrandCommand, CreateBrandResponse>
    {
        public Task<CreateBrandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            CreateBrandResponse response = new()
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            };
            return null;
        }
    }       
}