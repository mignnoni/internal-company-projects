using AutoMapper;
using OurProjects.Api.DTO;
using OurProjects.Data.Clients;
using OurProjects.Data.Models;
using OurProjects.Data.Repository;

namespace OurProjects.Api.Services
{
    public class TechnologyService : BaseService, ITechnologyService
    {
        private readonly TechnologyRep _repo;
        public TechnologyService(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
            _repo = new TechnologyRep(_uow);
        }

        public async Task Insert(CreateTechnologyDTO dto, Guid idCompany)
        {
            try
            {
                var model = _mapper.Map<Technology>(dto);
                model.IdCompany = idCompany;

                _repo.Insert(model);

                await _uow.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<ReadTechnologyDTO>> GetAll(Guid idCompany)
        {
            try
            {
                return _mapper.Map<List<ReadTechnologyDTO>>(await _repo.GetAll(idCompany));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
