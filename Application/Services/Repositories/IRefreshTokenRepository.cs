using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Application.Services.Repositories;

public interface IRefreshTokenRepository : IAsyncRepository<RefreshToken, int>
{
    Task<List<RefreshToken>> GetOldRefreshTokensByUserIdAsync(int userId, int refreshTokenTTL);
}
