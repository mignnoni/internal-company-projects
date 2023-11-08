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

        public async Task UpdateTechnologies(Guid idProject, List<UpdateProjectTechnologyDTO> technologies, Guid idCompany)
        {
            try
            {
                if (technologies is null || !technologies.Any())
                {
                    if (!await _repo.HasAnyTechnology(idProject, idCompany))
                        throw new ArgumentException("Não existe nenhuma tecnologia para ser excluída do projeto");

                    await _repo.DeleteAllTechnologies(idProject, idCompany);
                }
                else
                {
                    await HandleTechnologies(idProject, technologies, idCompany);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task HandleTechnologies(Guid idProject, List<UpdateProjectTechnologyDTO> technologies, Guid idCompany)
        {
            List<Guid> currentTechnologiesForProject = await _repo.GetTechnologies(idProject, idCompany);

            if (currentTechnologiesForProject.Any())
            {
                var technologiesToInsert = technologies.Where(x => !currentTechnologiesForProject.Exists(e => e == x.IdTechnology));

                var technologiesToDelete = currentTechnologiesForProject.Where(x => !technologies.Exists(e => e.IdTechnology == x));

                if (technologiesToDelete.Any())
                    await _repo.DeleteTechnologies(idProject, idCompany, technologiesToDelete);

                if (technologiesToInsert.Any())
                {
                    foreach (var item in technologiesToInsert)
                    {
                        _repo.InsertTechnology(_mapper.Map<ProjectTechnology>(item));
                    }

                    await _uow.SaveAsync();
                }
            }
            else if (technologies.Any())
            {
                foreach (var item in technologies)
                {
                    _repo.InsertTechnology(_mapper.Map<ProjectTechnology>(item));
                }

                await _uow.SaveAsync();
            }
            else
            {
                throw new ArgumentNullException(nameof(technologies));
            }
        }

        public async Task UpdateTeamMembers(Guid idProject, List<UpdateProjectTeamMemberDTO> teamMembers, Guid idCompany)
        {
            try
            {
                if (teamMembers is null || !teamMembers.Any())
                {
                    if (!await _repo.HasAnyTeamMember(idProject, idCompany))
                        throw new ArgumentException("Não existe nenhuma tecnologia para ser excluída do projeto");

                    await _repo.DeleteAllTeamMembers(idProject, idCompany);
                }
                else
                {
                    await HandleTeamMembers(idProject, teamMembers, idCompany);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task HandleTeamMembers(Guid idProject, List<UpdateProjectTeamMemberDTO> teamMembers, Guid idCompany)
        {
            List<Guid> currentTeamMembersForProject = await _repo.GetTeamMembers(idProject, idCompany);

            if (currentTeamMembersForProject.Any())
            {
                var teamMembersToInsert = teamMembers.Where(x => !currentTeamMembersForProject.Exists(e => e == x.IdTeamMember));

                var teamMembersToDelete = currentTeamMembersForProject.Where(x => !teamMembers.Exists(e => e.IdTeamMember == x));

                if (teamMembersToDelete.Any())
                    await _repo.DeleteTeamMembers(idProject, idCompany, teamMembersToDelete);

                if (teamMembersToInsert.Any())
                {
                    foreach (var item in teamMembersToInsert)
                    {
                        _repo.InsertTechnology(_mapper.Map<ProjectTechnology>(item));
                    }

                    await _uow.SaveAsync();
                }
            }
            else if (teamMembers.Any())
            {
                foreach (var item in teamMembers)
                {
                    _repo.InsertTechnology(_mapper.Map<ProjectTechnology>(item));
                }

                await _uow.SaveAsync();
            }
            else
            {
                throw new ArgumentNullException(nameof(teamMembers));
            }
        }
    }
}
