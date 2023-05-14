using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Api.Responses;
using Proyecto.Core.DTOs;
using Proyecto.Core.Interfaces;
using Proyecto.Core.Services;
using Proyecto.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IpeopleServices _peopleServices;

        private readonly IMapper _mapper;

        public PeopleController(IpeopleServices peopleServices, IMapper mapper)
        {
            _mapper = mapper;
            _peopleServices = peopleServices;
        }

        [HttpGet]
        public async  Task<IActionResult> GetPeople() 
        {
            var peoples = await _peopleServices.GetPeople();
            var peoplesDto =  _mapper.Map<IEnumerable<PeoplesDto>>(peoples);
            var response = new ApiResponse<IEnumerable<PeoplesDto>>(peoplesDto);

            return Ok(response);
        }
    }
}
