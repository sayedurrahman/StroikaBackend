using Microsoft.AspNetCore.Mvc;
using StudentRegister.Application.Commands.Interfaces;
using StudentRegister.Models.Commands;
using StudentRegister.Models.Queries;
using StudentRegister.Models.DTOs;
using StudentRegister.Models.Queries;
using StudentRegister.Application.Queries.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ICommandHandler<AddStudentCommand> addStudentCommandHandler;
        private readonly IQueryHandler<GetAllStudentsQuery, StudentDTO[]> getAllStudentsQueryHandler;

        public StudentsController(IQueryHandler<GetAllStudentsQuery, StudentDTO[]> getAllStudentsQueryHandler, ICommandHandler<AddStudentCommand> addStudentCommandHandler)
        {
            this.getAllStudentsQueryHandler = getAllStudentsQueryHandler;
            this.addStudentCommandHandler = addStudentCommandHandler;
        }

        /// <summary>
        /// GET: api/Students
        /// </summary>
        /// <returns>List of StudentDTO</returns>
        [HttpGet]
        public IEnumerable<StudentDTO> Get()
        {
            var query = new GetAllStudentsQuery();
            return getAllStudentsQueryHandler.Handle(query);
        }

        /// <summary>
        /// POST api/Students
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="dob"></param>
        /// <returns>Newly added StudentDTO</returns>
        [HttpPost]
        public StudentDTO Post(string firstName, string lastName, DateTime dob)
        {
            var command = new AddStudentCommand { FirstName = firstName, LastName = lastName, DateOfBirth = dob };
            int studentId = addStudentCommandHandler.Handle(command);
            return new StudentDTO { ID = studentId, FirstName = firstName, LastName = lastName, DateOfBirth = dob }; // No need to fetch data that are already available
        }

        // PUT api/Students/5
        //TODO: check input
        [HttpPut("{id}")]
        public StudentDTO Put(int id, [FromBody] string value)
        {
            return Get(0);
        }

        // GET api/Students/5/Nationality
        [HttpGet("{id}/Nationality")]
        public CitizenStudentDTO GetCitizenStudent(int id)
        {
            return null;
            //return new() { ID = 1, FirstName = "John", LastName = "Doe", NationalityId = 1 };
        }


        // PUT api/<StudentsController>/5/Nationality/{3}
        [HttpPut("{id}/Nationality/{nid}")]
        public CitizenStudentDTO PutNationalityOfStudent(int id, int nid)
        {
            return GetCitizenStudent(0);
        }

        // GET api/Students/5/FamilyMembers
        [HttpGet("{id}/FamilyMembers")]
        public FamilyMemberDTO[] GetFamilyMembersOfStudent(int id)
        {
            //return new FamilyMemberDTO[] { new() { ID = 1, FirstName = "John", LastName = "Doe", RelationshipId = 1, DateOfBirth = DateTime.Now } };
            return null;
        }

        // POST api/Students/5/FamilyMembers
        //TODO: check input
        [HttpPost("{id}/FamilyMembers")]
        public FamilyMemberDTO AddFamilyMemberOfStudent([FromBody] string value)
        {
            //return new() { ID = 1, FirstName = "John", LastName = "Doe", RelationshipId = 1, DateOfBirth = DateTime.Now };
            return null;
        }

        // GET api/Students/5
        //[HttpGet("{id}")]
        private StudentDTO Get(int id)
        {
            return null;
            //return new() { ID = 1, FirstName = "John", LastName = "Doe", DateOfBirth = DateTime.Parse("2023-07-31T12:44:55.403Z") };
        }
    }
}
