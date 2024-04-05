using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, int, BaseDbContext>,
    IUserOperationClaimRepository
{
    public UserOperationClaimRepository(BaseDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<OperationClaim>> GetOperationClaimsByUserIdAsync(int userId)
    {
        var operationClaims = await Query()
            .AsNoTracking()
            .Where(uoc => uoc.UserId == userId)
            .Select(uoc => new OperationClaim() { Id = uoc.OperationClaimId, Name = uoc.OperationClaim.Name })
            .ToListAsync();

        return operationClaims;
    }
}
