using BECase.Data.Repositories.Abstract;

namespace BECase.Data.Repositories
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        public IAppUserRepository appUserRepository { get; }
        public IJwtRefreshTokenRepository jwtRefreshTokenRepository { get; }

    }
}
