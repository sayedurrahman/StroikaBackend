using Microsoft.AspNetCore.Mvc;
using StudentRegister.Application;

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

        /// <summary>
        /// GET: api/Nationalities
        /// Get all nationalities
        /// </summary>
        /// <returns>Json: List of NationalityDTO</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(nationalityServices.GetAllNationalities(new()));
        }
    }
}
