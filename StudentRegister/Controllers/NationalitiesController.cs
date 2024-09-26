using Microsoft.AspNetCore.Mvc;
using StudentRegister.Application;
using StudentRegister.Models.DTOs;

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
        /// <returns>List of NationalityDTO</returns>
        [HttpGet]
        public IEnumerable<NationalityDTO> Get()
        {
            return nationalityServices.GetAllNationalities(new());
        }
    }
}
