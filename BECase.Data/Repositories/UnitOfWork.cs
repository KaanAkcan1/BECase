using BECase.Data.Context;
using BECase.Data.Repositories.Abstract;
using BECase.Data.Repositories.Concrate;

namespace BECase.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        private IAppUserRepository _appUserRepository;
        private IJwtRefreshTokenRepository _jwtRefreshTokenRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IAppUserRepository appUserRepository => _appUserRepository ?? new AppUserRepository();
        public IJwtRefreshTokenRepository jwtRefreshTokenRepository => _jwtRefreshTokenRepository ?? new JwtRefreshTokenRepository(_context);


        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
