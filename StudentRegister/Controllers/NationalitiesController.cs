using Microsoft.AspNetCore.Mvc;
using StudentRegister.Models.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalitiesController : ControllerBase
    {
        // GET: api/Nationalities
        [HttpGet]
        public IEnumerable<NationalityDTO> Get()
        {
            return new NationalityDTO[] { new() { Id = 1, Name="Bangladesh", AlphaCode = "BD" } };
        }
    }
}
