using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class RefreshTokenRepository : EfRepositoryBase<RefreshToken, int, BaseDbContext>, IRefreshTokenRepository
{
    public RefreshTokenRepository(BaseDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<RefreshToken>> GetOldRefreshTokensByUserIdAsync(int userId, int refreshTokenTTL)
    {
        var refreshTokens = await Query()
            .AsNoTracking()
            .Where(rt =>
                rt.UserId == userId
                && rt.Revoked == null
                && rt.CreatedDate.AddDays(refreshTokenTTL) <= DateTime.UtcNow
                && rt.Expires > DateTime.UtcNow)
            .ToListAsync();

        return refreshTokens;
    }
}
