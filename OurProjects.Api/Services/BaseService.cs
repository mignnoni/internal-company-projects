using AutoMapper;
using OurProjects.Data.Repository;

namespace OurProjects.Api.Services
{
    public class BaseService
    {
        public readonly IMapper _mapper;
        public readonly UnitOfWork _uow;

        public BaseService(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _uow = new UnitOfWork(context);
        }
    }
}
