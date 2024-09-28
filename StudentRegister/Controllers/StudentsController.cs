using Microsoft.AspNetCore.Mvc;
using StudentRegister.Application;
using StudentRegister.Models.Commands;
using StudentRegister.Models.DTOs;
using StudentRegister.Models.Queries;

namespace StudentRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentServices studentServices;
        private readonly IFamilyMemberService familyMemberService;

        public StudentsController(IStudentServices studentServices, IFamilyMemberService familyMemberService)
        {
            this.studentServices = studentServices;
            this.familyMemberService = familyMemberService;
        }

        /// <summary>
        /// POST api/Students
        /// Add new student
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="dateOfBirth"></param>
        /// <returns>Json: Newly added StudentDTO</returns>
        [HttpPost]
        public IActionResult Post([FromBody] StudentDTO student)
        {
            var command = new AddStudentCommand { FirstName = student.FirstName, LastName = student.LastName, DateOfBirth = student.DateOfBirth };
            return Ok(studentServices.AddStudent(command));
        }

        /// <summary>
        /// PUT api/Students/{id}
        /// Update student
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="dob"></param>
        /// <returns>Json: Updated student</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, string firstName, string lastName, DateTime dob)
        {
            var command = new UpdateStudentCommand { Id = id, FirstName = firstName, LastName = lastName, DateOfBirth = dob };
            return Ok(studentServices.UpdateStudent(command));
        }

        /// <summary>
        /// PUT api/Students/{studentId}/Nationality/{NationalityId}
        /// Update student's nationality
        /// </summary>
        /// <param name="id">studentId</param>
        /// <param name="nid">NationalityId</param>
        /// <returns>Json: Student with nationality</returns>
        [HttpPut("{id}/Nationality/{nid}")]
        public IActionResult UpdateNationalityOfStudent(int id, int nid)
        {
            var command = new UpdateStudentNationalityCommand { StudentId = id, NationalityId = nid };
            return Ok(studentServices.UpdateStudentNationality(command));
        }

        /// <summary>
        /// POST api/Students/{id}/FamilyMembers
        /// Add family member
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="dob"></param>
        /// <param name="relationshipId"></param>
        /// <returns>Json: Newly added family member</returns>
        [HttpPost("{id}/FamilyMembers")]
        public IActionResult AddFamilyMemberOfStudent(int id, string firstName, string lastName, DateTime dob, int relationshipId)
        {
            var command = new AddFamilyMemberCommand { StudentId = id, FirstName = firstName, LastName = lastName, DateOfBirth = dob, RelationshipId = relationshipId };
            return Ok(familyMemberService.AddStudentFamilyMember(command));
        }

        /// <summary>
        /// GET: api/Students
        /// Get all students
        /// </summary>
        /// <returns>Json: List of StudentDTO</returns>
        [HttpGet]
        public IActionResult Get()
        {
            var query = new GetAllStudentsQuery();
            return Ok(studentServices.GetAllStudents(query));
        }

        /// <summary>
        /// GET api/Students/{id}/Nationality
        /// Get student info with nationality
        /// </summary>
        /// <param name="id">Student id</param>
        /// <returns>Json: Student with nationality</returns>
        [HttpGet("{id}/Nationality")]
        public IActionResult GetCitizenStudent(int id)
        {
            var query = new GetStudentWithNationalityQuery() { StudentId = id };
            return Ok(studentServices.GetStudentWithNationality(query));
        }

        /// <summary>
        /// GET api/Students/{id}/FamilyMembers
        /// Get all family member of a student
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Json: Family members</returns>
        [HttpGet("{id}/FamilyMembers")]
        public IActionResult GetStudentFamilyMembers(int id)
        {
            var query = new GetStudentFamilyMembersQuery() { StudentId = id };
            return Ok(studentServices.GetStudentFamilyMembers(query));
        }
    }
}
