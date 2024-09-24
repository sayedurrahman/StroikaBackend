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

        public StudentsController(IStudentServices studentServices)
        {
            this.studentServices = studentServices;
        }

        /// <summary>
        /// POST api/Students
        /// Add new student
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="dob"></param>
        /// <returns>Newly added StudentDTO</returns>
        [HttpPost]
        public StudentDTO Post(string firstName, string lastName, DateTime dob)
        {
            var command = new AddStudentCommand { FirstName = firstName, LastName = lastName, DateOfBirth = dob };
            return studentServices.AddStudent(command);
        }

        /// <summary>
        /// PUT api/Students/{id}
        /// Update student
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="dob"></param>
        /// <returns>Updated student</returns>
        [HttpPut("{id}")]
        public StudentDTO Put(int id, string firstName, string lastName, DateTime dob)
        {
            var command = new UpdateStudentCommand { Id = id, FirstName = firstName, LastName = lastName, DateOfBirth = dob };
            return studentServices.UpdateStudent(command);
        }

        /// <summary>
        /// PUT api/Students/{studentId}/Nationality/{NationalityId}
        /// Update student nationality
        /// </summary>
        /// <param name="id">studentId</param>
        /// <param name="nid">NationalityId</param>
        /// <returns>Student with nationality</returns>
        [HttpPut("{id}/Nationality/{nid}")]
        public CitizenStudentDTO UpdateNationalityOfStudent(int id, int nid)
        {
            var command = new UpdateStudentNationalityCommand { StudentId = id, NationalityId = nid };
            return studentServices.UpdateStudentNationality(command);
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
        /// <returns>Newly added family member</returns>
        [HttpPost("{id}/FamilyMembers")]
        public FamilyMemberDTO AddFamilyMemberOfStudent(int id, string firstName, string lastName, DateTime dob, int relationshipId)
        {
            var command = new AddFamilyMemberCommand { StudentId = id, FirstName = firstName, LastName = lastName, DateOfBirth = dob, RelationshipId = relationshipId };
            return studentServices.AddStudentFamilyMember(command);
        }

        /// <summary>
        /// GET: api/Students
        /// Get all students
        /// </summary>
        /// <returns>List of StudentDTO</returns>
        [HttpGet]
        public IEnumerable<StudentDTO> Get()
        {
            var query = new GetAllStudentsQuery();
            return studentServices.GetAllStudents(query);
        }

        /// <summary>
        /// GET api/Students/{id}/Nationality
        /// Get student info with nationality
        /// </summary>
        /// <param name="id">Student id</param>
        /// <returns>Student with nationality</returns>
        [HttpGet("{id}/Nationality")]
        public CitizenStudentDTO GetCitizenStudent(int id)
        {
            var query = new GetStudentWithNationalityQuery() { StudentId = id };
            return studentServices.GetStudentWithNationality(query);
        }

        /// <summary>
        /// GET api/Students/{id}/FamilyMembers
        /// Get all family member of a student
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Family members</returns>
        [HttpGet("{id}/FamilyMembers")]
        public FamilyMemberDTO[] GetStudentFamilyMembers(int id)
        {
            var query = new GetStudentFamilyMembersQuery() { StudentId = id };
            return studentServices.GetStudentFamilyMembers(query);
        }
    }
}
