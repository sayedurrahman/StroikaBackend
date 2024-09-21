using Microsoft.AspNetCore.Mvc;
using StudentRegister.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // GET: api/Students
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return new Student[] {
                new() { ID = 1, FirstName = "John", LastName= "Doe", DateOfBirth = DateTime.Parse("2023-07-31T12:44:55.403Z")},
                new() { ID = 2, FirstName = "John2", LastName= "Doe2", DateOfBirth = DateTime.Parse("2023-07-31T12:44:55.403Z")}
            };
        }

        // GET api/Students/5
        //[HttpGet("{id}")]
        private Student Get(int id)
        {
            return new() { ID = 1, FirstName = "John", LastName = "Doe", DateOfBirth = DateTime.Parse("2023-07-31T12:44:55.403Z") };
        }

        // POST api/Students
        //TODO: check input
        [HttpPost]
        public Student Post([FromBody] string value)
        {
            return Get(0);
        }

        // PUT api/Students/5
        //TODO: check input
        [HttpPut("{id}")]
        public Student Put(int id, [FromBody] string value)
        {
            return Get(0);
        }

        // GET api/Students/5/Nationality
        [HttpGet("{id}/Nationality")]
        public CitizenStudent GetCitizenStudent(int id)
        {
            return new() { ID = 1, FirstName = "John", LastName = "Doe", NationalityId = 1 };
        }


        // PUT api/<StudentsController>/5/Nationality/{3}
        [HttpPut("{id}/Nationality/{nid}")]
        public CitizenStudent PutNationalityOfStudent(int id, int nid)
        {
            return GetCitizenStudent(0);
        }

        // GET api/Students/5/FamilyMembers
        [HttpGet("{id}/FamilyMembers")]
        public FamilyMember[] GetFamilyMembersOfStudent(int id)
        {
            return new FamilyMember[] { new() { ID = 1, FirstName = "John", LastName = "Doe", RelationshipId = 1, DateOfBirth = DateTime.Now } };
        }

        // POST api/Students/5/FamilyMembers
        //TODO: check input
        [HttpPost("{id}/FamilyMembers")]
        public FamilyMember AddFamilyMemberOfStudent([FromBody] string value)
        {
            return new() { ID = 1, FirstName = "John", LastName = "Doe", RelationshipId = 1, DateOfBirth = DateTime.Now };
        }

        //// DELETE api/<StudentsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
