using Microsoft.AspNetCore.Mvc;
using StudentRegister.DataAccess.Queries;
using StudentRegister.DataAccess.Queries.Interfaces;
using StudentRegister.Models.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalitiesController : ControllerBase
    {
        public NationalitiesController(INationalityQueryRepository nationalityQueryRepository)
        {
            NationalityQueryRepository = nationalityQueryRepository;
        }

        public INationalityQueryRepository NationalityQueryRepository { get; }

        // GET: api/Nationalities
        [HttpGet]
        public IEnumerable<NationalityDTO> Get()
        {
            return NationalityQueryRepository.GetAll();
        }
    }
}
