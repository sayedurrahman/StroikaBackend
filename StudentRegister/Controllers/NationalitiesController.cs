using Microsoft.AspNetCore.Mvc;
using StudentRegister.Application;
using StudentRegister.Models.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalitiesController : ControllerBase
    {
        public NationalitiesController(INationalityServices nationalityServices)
        {
            this.nationalityServices = nationalityServices;
        }

        public INationalityServices nationalityServices { get; }

        // GET: api/Nationalities
        [HttpGet]
        public IEnumerable<NationalityDTO> Get()
        {
            return nationalityServices.GetAllNationalities(new());
        }
    }
}
