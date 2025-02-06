using BECase.Data.Repositories.Abstract;

namespace BECase.Data.Repositories
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        public IAppUserRepository appUserRepository { get; }
        public ICustomerRepository customerRepository { get; }
        public IInvoiceLineRepository invoiceLineRepository { get; }
        public IInvoiceRepository invoiceRepository { get; }
        public IJwtRefreshTokenRepository jwtRefreshTokenRepository { get; }

    }
}
