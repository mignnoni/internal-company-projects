using OurProjects.Data.Models;

namespace OurProjects.Data.Repository
{
    public class UnitOfWork : IAsyncDisposable
    {
        private readonly AppDbContext _context;

        private GenericRepository<Company> companyRepository;
        private GenericRepository<User> userRepository;
        private GenericRepository<Area> areaRepository;
        private GenericRepository<Technology> technologyRepository;
        private GenericRepository<Project> projectRepository;
        private GenericRepository<ProjectTechnology> projectTechnologyRepository;
        private GenericRepository<ProjectTeamMember> projectTeamMemberRepository;

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

        public GenericRepository<User> UserRepository
        {
            get
            {
                this.userRepository ??= new GenericRepository<User>(_context);
                return userRepository;
            }
        }

        public GenericRepository<Area> AreaRepository
        {
            get
            {
                this.areaRepository ??= new GenericRepository<Area>(_context);
                return areaRepository;
            }
        }

        public GenericRepository<Technology> TechnologyRepository
        {
            get
            {
                this.technologyRepository ??= new GenericRepository<Technology>(_context);
                return technologyRepository;
            }
        }

        public GenericRepository<Project> ProjectRepository
        {
            get
            {
                this.projectRepository ??= new GenericRepository<Project>(_context);
                return projectRepository;
            }
        }

        public GenericRepository<ProjectTechnology> ProjectTechnologyRepository
        {
            get
            {
                this.projectTechnologyRepository ??= new GenericRepository<ProjectTechnology>(_context);
                return projectTechnologyRepository;
            }
        }

        public GenericRepository<ProjectTeamMember> ProjectTeamMemberRepository
        {
            get
            {
                this.projectTeamMemberRepository ??= new GenericRepository<ProjectTeamMember>(_context);
                return projectTeamMemberRepository;
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
