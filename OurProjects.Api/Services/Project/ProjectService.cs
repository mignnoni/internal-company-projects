using AutoMapper;
using OurProjects.Api.DTO;
using OurProjects.Data.Clients;
using OurProjects.Data.Models;
using OurProjects.Data.Repository;

namespace OurProjects.Api.Services
{
    public class ProjectService : BaseService, IProjectService
    {
        private readonly ProjectRep _repo;
        public ProjectService(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
            _repo = new ProjectRep(_uow);
        }

        public async Task Insert(CreateProjectDTO dto, Guid idCompany)
        {
            try
            {
                var model = _mapper.Map<Project>(dto);
                model.IdCompany = idCompany;

                _repo.Insert(model);
                await _uow.SaveAsync();

                if (dto.TeamMembersId != null)
                {
                    var repoTeamMembers = _uow.ProjectTeamMemberRepository;

                    foreach (var teamMemberId in dto.TeamMembersId)
                    {
                        repoTeamMembers.Add(new ProjectTeamMember
                        {
                            Id = Guid.NewGuid(),
                            IdProject = model.Id,
                            IdTeamMember = teamMemberId
                        });
                    }

                    await _uow.SaveAsync();
                }

                if (dto.TechnologiesId != null)
                {
                    var repoTechnologies = _uow.ProjectTechnologyRepository;

                    foreach (var technologyId in dto.TechnologiesId)
                    {
                        repoTechnologies.Add(new ProjectTechnology
                        {
                            Id = Guid.NewGuid(),
                            IdProject = model.Id,
                            IdTechnology = technologyId
                        });
                    }

                    await _uow.SaveAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<ReadProjectDTO>> GetAll(Guid idCompany)
        {
            try
            {
                var projects = await _repo.GetAll(idCompany);
                return _mapper.Map<List<ReadProjectDTO>>(projects);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
