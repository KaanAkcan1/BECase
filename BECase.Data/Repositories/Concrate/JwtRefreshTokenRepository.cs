using BECase.Data.Context;
using BECase.Data.Models;
using BECase.Data.Repositories.Abstract;

namespace BECase.Data.Repositories.Concrate
{
    public class JwtRefreshTokenRepository : Repository<JwtRefreshToken>, IJwtRefreshTokenRepository
    {
        public JwtRefreshTokenRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
