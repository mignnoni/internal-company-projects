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

        public async Task UpdateTitle(UpdatereaDTO dto, Guid idCompany)
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

        public async Task<ReadAreaDTO> GetById(Guid id, Guid idCompany)
        {
            try
            {
                return _mapper.Map<ReadAreaDTO>(await _repo.GetById(id, idCompany));
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
                    throw new ArgumentException("Área não encontrada");

                await _repo.Inactivate(id, idCompany);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
