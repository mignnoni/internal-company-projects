using AutoMapper;
using OurProjects.Api.DTO;
using OurProjects.Data.Clients;
using OurProjects.Data.Models;
using OurProjects.Data.Repository;

namespace OurProjects.Api.Services
{
    public class AreaService : BaseService, IAreaService
    {
        private readonly AreaRep _repo;
        public AreaService(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
            _repo = new AreaRep(_uow);
        }

        public async Task Insert(CreateAreaDTO dto, Guid idCompany)
        {
            try
            {
                var model = _mapper.Map<Area>(dto);
                model.IdCompany = idCompany;

                _repo.Insert(model);

                await _uow.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<ReadAreaDTO>> GetAll(Guid idCompany)
        {
            try
            {
                return _mapper.Map<List<ReadAreaDTO>>(await _repo.GetAll(idCompany));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
