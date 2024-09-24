using Microsoft.AspNetCore.Mvc;
using StudentRegister.Application.Commands.Interfaces;
using StudentRegister.Models.Commands;
using StudentRegister.Models.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ICommandHandler<AddStudentCommand> addStudentHandler;

        public StudentsController(ICommandHandler<AddStudentCommand> addStudentHandler)
        {
            this.addStudentHandler = addStudentHandler;
        }

        // GET: api/Students
        [HttpGet]
        public IEnumerable<StudentDTO> Get()
        {
            return new StudentDTO[] {
                //new() { ID = 1, FirstName = "John", LastName= "Doe", DateOfBirth = DateTime.Parse("2023-07-31T12:44:55.403Z")},
                //new() { ID = 2, FirstName = "John2", LastName= "Doe2", DateOfBirth = DateTime.Parse("2023-07-31T12:44:55.403Z")}
            };
        }

        // GET api/Students/5
        //[HttpGet("{id}")]
        private StudentDTO Get(int id)
        {
            return null;
            //return new() { ID = 1, FirstName = "John", LastName = "Doe", DateOfBirth = DateTime.Parse("2023-07-31T12:44:55.403Z") };
        }

        // POST api/Students
        [HttpPost]
        public StudentDTO Post(string firstName, string lastName, DateTime dob)
        {
            var command = new AddStudentCommand { FirstName = firstName, LastName = lastName, DateOfBirth = dob };
            int studentId = addStudentHandler.Handle(command);
            return new StudentDTO { ID = studentId, FirstName = firstName, LastName = lastName, DateOfBirth = dob };
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

        //// DELETE api/<StudentsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
