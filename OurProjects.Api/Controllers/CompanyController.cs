﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OurProjects.Api.DTO;
using OurProjects.Api.Services;
using OurProjects.Api.Services.JWT;
using OurProjects.Data.Models;

namespace OurProjects.Api.Controllers
{
    [Authorize(Roles = Roles.Dev)]
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _service;

        public CompanyController(ICompanyService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<Company>> GetAll()
        {
            try
            {
                return await _service.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task Insert(CreateCompanyDTO dto)
        {
            try
            {
                await _service.Insert(dto);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
