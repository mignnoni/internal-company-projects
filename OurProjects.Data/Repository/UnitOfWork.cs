using OurProjects.Data.Models;

namespace OurProjects.Data.Repository
{
    public class UnitOfWork : IAsyncDisposable
    {
        private readonly AppDbContext _context;

        private GenericRepository<Company> companyRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public GenericRepository<Company> CompanyRepository
        {
            get
            {
                this.companyRepository ??= new GenericRepository<Company>(_context);
                return companyRepository;
            }
        }

        public Task SaveAsync()
        {
            return _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual async Task Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    await _context.DisposeAsync();
                }
            }
            this.disposed = true;
        }

        public async ValueTask DisposeAsync()
        {
            await Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
