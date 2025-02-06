using BECase.Data.Context;
using BECase.Data.Repositories.Abstract;
using BECase.Data.Repositories.Concrate;

namespace BECase.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        private IAppUserRepository _appUserRepository;
        private ICustomerRepository _customerRepository;
        private IInvoiceLineRepository _invoiceLineRepository;
        private IInvoiceRepository _invoiceRepository;
        private IJwtRefreshTokenRepository _jwtRefreshTokenRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IAppUserRepository appUserRepository => _appUserRepository ?? new AppUserRepository();
        public ICustomerRepository customerRepository => _customerRepository ?? new CustomerRepository(_context);
        public IInvoiceLineRepository invoiceLineRepository => _invoiceLineRepository ?? new InvoiceLineRepository(_context);
        public IInvoiceRepository invoiceRepository => _invoiceRepository ?? new InvoiceRepository(_context);
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
