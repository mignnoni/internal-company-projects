﻿using OurProjects.Api.DTO;
using OurProjects.Api.DTO.Identity;

namespace OurProjects.Api.Services.Identity
{
    public interface IIdentityService
    {
        Task CreateAdmin(CreateUserDTO dto, Guid idCompany);
        Task CreateMember(CreateUserDTO dto, Guid idCompany);
        Task CreateManager(CreateUserDTO dto, Guid idCompany);
        Task<List<ReadUserDTO>> GetByCompany(Guid idCompany);
        Task<LoginResponseDTO> Login(LoginRequestDTO dto);
    }
}
