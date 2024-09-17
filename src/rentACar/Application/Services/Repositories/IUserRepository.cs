using Core.Persistence.Repositories;
using Core.Security.Entities;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IUserRepository : IAsyncRepository<User, int>, IRepository<User, int> { }

public interface IUserOperationClaimRepository : IAsyncRepository<UserOperationClaim, int>, IRepository<UserOperationClaim, int>
{
    Task<IList<OperationClaim>> GetOperationClaimsByUserIdAsync(int userId);
}




