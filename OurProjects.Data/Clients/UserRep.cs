using Microsoft.EntityFrameworkCore;
using OurProjects.Data.Models;
using OurProjects.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProjects.Data.Clients
{
    public sealed class UserRep
    {
        private readonly IRepository<User> _repo;

        public UserRep(UnitOfWork uow)
        {
            _repo = uow.UserRepository;
        }

        public Task<List<User>> GetByCompany(Guid idCompany)
        {
            return _repo.Query
                .Where(x => !x.Idle && x.IdCompany == idCompany)
                .ToListAsync();
        }



    }
}
