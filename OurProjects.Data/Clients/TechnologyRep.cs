using Microsoft.EntityFrameworkCore;
using OurProjects.Data.Models;
using OurProjects.Data.Repository;


namespace OurProjects.Data.Clients
{
    public sealed class TechnologyRep
    {
        private readonly IRepository<Technology> _repo;

        public TechnologyRep(UnitOfWork uow)
        {
            _repo = uow.TechnologyRepository;
        }

        public Task<Technology?> GetById(Guid id, Guid idCompany)
        {
            return _repo.Query
                    .FirstOrDefaultAsync(x => x.Id == id && x.IdCompany == idCompany);
        }

        public Task<List<Technology>> GetAll(Guid idCompany)
        {
            return _repo.Query
                .Where(x => !x.Idle && x.IdCompany == idCompany)
                .ToListAsync();
        }

        public void Insert(Technology model)
        {
            _repo.Add(model);
        }

        public Task UpdateTitle(Guid id, Guid idCompany, string title)
        {
            return _repo.Query
                .Where(x => x.Id == id && x.IdCompany == idCompany)
                .ExecuteUpdateAsync(u =>
                    u.SetProperty(p => 
                        p.Title, title));
        }

        public Task Inactivate(Guid id, Guid idCompany)
        {
            return _repo.Query
                .Where(x => x.Id == id && x.IdCompany == idCompany)
                .ExecuteUpdateAsync(u =>
                    u.SetProperty(p =>
                        p.Idle, true));
        }


    }
}
