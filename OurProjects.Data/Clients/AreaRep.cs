using Microsoft.EntityFrameworkCore;
using OurProjects.Data.Models;
using OurProjects.Data.Repository;


namespace OurProjects.Data.Clients
{
    public sealed class AreaRep
    {
        private readonly IRepository<Area> _repo;

        public AreaRep(UnitOfWork uow)
        {
            _repo = uow.AreaRepository;
        }

        public Task<Area?> GetById(Guid id, Guid idCompany)
        {
            return _repo.Query
                    .FirstOrDefaultAsync(x => x.Id == id && x.IdCompany == idCompany);
        }

        public Task<List<Area>> GetAll(Guid idCompany)
        {
            return _repo.Query
                .Where(x => !x.Idle && x.IdCompany == idCompany)
                .ToListAsync();
        }

        public void Insert(Area model)
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
