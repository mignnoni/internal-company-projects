using Microsoft.EntityFrameworkCore;
using OurProjects.Data.Models;
using OurProjects.Data.Repository;


namespace OurProjects.Data.Clients
{
    public sealed class ProjectRep
    {
        private readonly IRepository<Project> _repo;
        private readonly IRepository<ProjectTechnology> _repoTechnology;
        private readonly IRepository<ProjectTeamMember> _repoTeamMember;


        public ProjectRep(UnitOfWork uow)
        {
            _repo = uow.ProjectRepository;
            _repoTechnology = uow.ProjectTechnologyRepository;
            _repoTeamMember = uow.ProjectTeamMemberRepository;
        }

        public Task<Project?> GetById(Guid id, Guid idCompany)
        {
            return _repo.Query
                    .FirstOrDefaultAsync(x => x.Id == id && x.IdCompany == idCompany);
        }

        public Task<bool> Exists(Guid id, Guid idCompany)
        {
            return _repo.Query
                .AnyAsync(x => x.Id == id && x.IdCompany == idCompany);
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

        public Task<List<Guid>> GetTeamMembers(Guid idProject, Guid idCompany)
        {
            return _repoTeamMember.Query
                .Where(x => x.IdProject == idProject && x.Project.IdCompany == idCompany)
                .Select(s => s.IdTeamMember)
                .ToListAsync();
        }

        public Task<List<Guid>> GetTechnologies(Guid idProject, Guid idCompany)
        {
            return _repoTechnology.Query
                .Where(x => x.IdProject == idProject && x.Project.IdCompany == idCompany)
                .Select(s => s.IdTechnology)
                .ToListAsync();
        }

        public void Insert(Project model)
        {
            _repo.Add(model);
        }

        public void Update (Project model)
        {
            _repo.Update(model);
        }

        public Task Inactivate(Guid id, Guid idCompany)
        {
            return _repo.Query
                .Where(x => x.Id == id && x.IdCompany == idCompany)
                .ExecuteUpdateAsync(u =>
                    u.SetProperty(p =>
                        p.Idle, true));
        }

        public Task<bool> HasAnyTechnology(Guid idProject, Guid idCompany)
        {
            return _repoTechnology.Query
                .AnyAsync(x => x.IdProject == idProject && x.Project.IdCompany == idCompany);
        }

        public Task DeleteAllTechnologies(Guid idProject, Guid idCompany)
        {
            return _repoTechnology.Query
                .Where(x => x.IdProject == idProject && x.Project.IdCompany == idCompany)
                .ExecuteDeleteAsync();
        }

        public Task DeleteTechnologies(Guid idProject, Guid idCompany, IEnumerable<Guid> idTechnologies)
        {
            return _repoTechnology.Query
                .Where(x => x.IdProject == idProject && x.Project.IdCompany == idCompany && idTechnologies.Contains(x.IdTechnology))
                .ExecuteDeleteAsync();
        }

        public void InsertTechnology(ProjectTechnology model)
        {
            _repoTechnology.Add(model);
        }

        public Task<bool> HasAnyTeamMember(Guid idProject, Guid idCompany)
        {
            return _repoTeamMember.Query
                .AnyAsync(x => x.IdProject == idProject && x.Project.IdCompany == idCompany);
        }

        public Task DeleteAllTeamMembers(Guid idProject, Guid idCompany)
        {
            return _repoTeamMember.Query
                .Where(x => x.IdProject == idProject && x.Project.IdCompany == idCompany)
                .ExecuteDeleteAsync();
        }

        public Task DeleteTeamMembers(Guid idProject, Guid idCompany, IEnumerable<Guid> idTeamMembers)
        {
            return _repoTeamMember.Query
                .Where(x => x.IdProject == idProject && x.Project.IdCompany == idCompany && idTeamMembers.Contains(x.IdTeamMember))
                .ExecuteDeleteAsync();
        }

        public void InsertTeamMember(ProjectTeamMember model)
        {
            _repoTeamMember.Add(model);
        }
    }
}
