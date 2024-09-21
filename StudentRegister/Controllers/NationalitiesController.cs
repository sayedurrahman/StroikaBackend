using Microsoft.AspNetCore.Mvc;
using StudentRegister.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalitiesController : ControllerBase
    {
        // GET: api/Nationalities
        [HttpGet]
        public IEnumerable<Nationality> Get()
        {
            return new Nationality[] { new() { Id = 1, Title="Bangladesh", Value = "BD" } };
        }
    }
}
