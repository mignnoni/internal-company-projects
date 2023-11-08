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

        public async Task UpdateTitle(UpdateTechnologyDTO dto, Guid idCompany)
        {
            try
            {
                if (string.IsNullOrEmpty(dto.Title))
                    throw new ArgumentNullException(nameof(dto.Title));

                var oldArea = await _repo.GetById(dto.Id, idCompany);

                if (oldArea is null)
                    throw new ArgumentNullException(nameof(oldArea));

                var title = dto.Title.Trim();

                if (oldArea.Title == title)
                    throw new ArgumentException("O título precisa ser diferente do atual para ser atualizado");

                await _repo.UpdateTitle(dto.Id, idCompany, title);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ReadTechnologyDTO> GetById(Guid id, Guid idCompany)
        {
            try
            {
                return _mapper.Map<ReadTechnologyDTO>(await _repo.GetById(id, idCompany));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Delete(Guid id, Guid idCompany)
        {
            try
            {
                if (!await _repo.Exists(id, idCompany))
                    throw new ArgumentException("Tecnologia não encontrada");

                await _repo.Inactivate(id, idCompany);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
