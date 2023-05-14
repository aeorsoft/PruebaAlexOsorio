using Microsoft.AspNetCore.Mvc;
using Proyecto.Core.Interfaces;
using System.Threading.Tasks;

namespace Proyecto.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleApiController : ControllerBase
    {
        private readonly IPeopleApiServices _ipeopleapiservices;

        public PeopleApiController(IPeopleApiServices ipeopleapiservices)
        {
            _ipeopleapiservices = ipeopleapiservices;
        }

        [HttpGet]
        public  async Task<IActionResult> Get()
        {
            var peoples = await _ipeopleapiservices.Get();
           
            return Ok(peoples);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var peoples = await _ipeopleapiservices.GetId(id);

            return Ok(peoples);
        }
    }
}
