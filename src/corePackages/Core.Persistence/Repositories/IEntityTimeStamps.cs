namespace Core.Persistence.Repositories;

public interface IEntityTimestamps
{
     DateTime CreatedAt { get; set; }
    
     DateTime? UpdatedAt { get; set; }
     
     DateTime? DeletedAt { get; set; }
}