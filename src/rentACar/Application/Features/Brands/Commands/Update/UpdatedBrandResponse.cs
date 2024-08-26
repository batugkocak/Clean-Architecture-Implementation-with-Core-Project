namespace Application.Features.Brands.Commands.Update;

public class UpdatedBrandResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
}