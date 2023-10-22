using Microsoft.EntityFrameworkCore;
using OurProjects.Data.Models;
using OurProjects.Data.Repository;


namespace OurProjects.Data.Clients
{
    public sealed class ProjectRep
    {
        private readonly IRepository<Project> _repo;

        public ProjectRep(UnitOfWork uow)
        {
            _repo = uow.ProjectRepository;
        }

        public Task<Project?> GetById(Guid id, Guid idCompany)
        {
            return _repo.Query
                    .FirstOrDefaultAsync(x => x.Id == id && x.IdCompany == idCompany);
        }

        public Task<List<Project>> GetAll(Guid idCompany)
        {
            return _repo.Query
                .Where(x => !x.Idle && x.IdCompany == idCompany)
                .Include(i => i.Area)
                .Include(i => i.UserLeader)
                .Include(i => i.ProjectTeamMembers)
                    .ThenInclude(ii => ii.TeamMember)
                .Include(i => i.ProjectTechnologies)
                    .ThenInclude(ii => ii.Technology)
                .ToListAsync();
        }

        public void Insert(Project model)
        {
            _repo.Add(model);
        }

        //public Task UpdateTitle(Guid id, Guid idCompany, string title)
        //{
        //    return _repo.Query
        //        .Where(x => x.Id == id && x.IdCompany == idCompany)
        //        .ExecuteUpdateAsync(u =>
        //            u.SetProperty(p => 
        //                p.Title, title));
        //}

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
