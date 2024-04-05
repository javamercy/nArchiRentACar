using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Application.Services.Repositories;

public interface IUserOperationClaimRepository : IAsyncRepository<UserOperationClaim, int>
{
    Task<List<OperationClaim>> GetOperationClaimsByUserIdAsync(int userId);
}