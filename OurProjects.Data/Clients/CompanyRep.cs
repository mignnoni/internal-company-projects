using Microsoft.EntityFrameworkCore;
using OurProjects.Data.Models;
using OurProjects.Data.Repository;


namespace OurProjects.Data.Clients
{
    public sealed class CompanyRep
    {
        private readonly IRepository<Company> _repo;

        public CompanyRep(UnitOfWork uow)
        {
            _repo = uow.CompanyRepository;
        }

        public Task<List<Company>> GetAll()
        {
            return _repo.Query
                .Where(x => !x.Idle)
                .ToListAsync();
        }

        public void Insert(Company model)
        {
            _repo.Add(model);
        }


    }
}
