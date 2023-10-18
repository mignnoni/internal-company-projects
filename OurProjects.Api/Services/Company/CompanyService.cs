using AutoMapper;
using OurProjects.Api.DTO;
using OurProjects.Data.Clients;
using OurProjects.Data.Models;
using OurProjects.Data.Repository;

namespace OurProjects.Api.Services
{
    public class CompanyService : BaseService, ICompanyService
    {
        private readonly CompanyRep _repo;
        public CompanyService(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
            _repo = new CompanyRep(_uow);
        }

        public async Task Insert(CreateCompanyDTO dto)
        {
            try
            {
                var model = new Company
                {
                    Id = Guid.NewGuid(),
                    Name = dto.Name,
                    Idle = false,
                    CreatedAt = DateTime.UtcNow,
                };

                _repo.Insert(model);

                await _uow.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Company>> GetAll()
        {
            try
            {
                return await _repo.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
