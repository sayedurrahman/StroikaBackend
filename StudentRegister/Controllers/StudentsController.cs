using Microsoft.AspNetCore.Mvc;
using StudentRegister.Application.Commands.Interfaces;
using StudentRegister.Application.Queries.Interfaces;
using StudentRegister.Models.Commands;
using StudentRegister.Models.DTOs;
using StudentRegister.Models.Queries;

namespace StudentRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ICommandHandler<AddStudentCommand> addStudentCommandHandler;
        private readonly ICommandHandler<UpdateStudentCommand> updateStudentCommandHandler;
        private readonly ICommandHandler<UpdateStudentNationalityCommand> updateStudentNationalityCommandHandler;
        private readonly ICommandHandler<AddFamilyMemberCommand> addFamilyMemberCommandHandler;
        private readonly IQueryHandler<GetAllStudentsQuery, StudentDTO[]> getAllStudentsQueryHandler;
        private readonly IQueryHandler<GetStudentQuery, StudentDTO> getStudentQueryHandler;
        private readonly IQueryHandler<GetStudentWithNationalityQuery, CitizenStudentDTO> getStudentWithNationalityQueryHandler;
        private readonly IQueryHandler<GetStudentFamilyMembersQuery, FamilyMemberDTO[]> getStudentFamilyMembersQueryHandler;

        public StudentsController(ICommandHandler<AddStudentCommand> addStudentCommandHandler,
                                   ICommandHandler<UpdateStudentCommand> updateStudentCommandHandler,
                                   ICommandHandler<UpdateStudentNationalityCommand> updateStudentNationalityCommandHandler,
                                   ICommandHandler<AddFamilyMemberCommand> addFamilyMemberCommandHandler,
                                   IQueryHandler<GetAllStudentsQuery, StudentDTO[]> getAllStudentsQueryHandler,
                                   IQueryHandler<GetStudentQuery, StudentDTO> getStudentQueryHandler,
                                   IQueryHandler<GetStudentWithNationalityQuery, CitizenStudentDTO> getStudentWithNationalityQueryHandler,
                                   IQueryHandler<GetStudentFamilyMembersQuery, FamilyMemberDTO[]> getStudentFamilyMembersQueryHandler)
        {
            this.addStudentCommandHandler = addStudentCommandHandler;
            this.updateStudentCommandHandler = updateStudentCommandHandler;
            this.updateStudentNationalityCommandHandler = updateStudentNationalityCommandHandler;
            this.addFamilyMemberCommandHandler = addFamilyMemberCommandHandler;
            this.getAllStudentsQueryHandler = getAllStudentsQueryHandler;
            this.getStudentQueryHandler = getStudentQueryHandler;
            this.getStudentWithNationalityQueryHandler = getStudentWithNationalityQueryHandler;
            this.getStudentFamilyMembersQueryHandler = getStudentFamilyMembersQueryHandler;
        }

        #region == Command ==

        /// <summary>
        /// POST api/Students; Add new student
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
            return new StudentDTO { ID = studentId, FirstName = firstName, LastName = lastName, DateOfBirth = dob };
            // No exception means data stored; So no need to fetch data that are already available
        }

        /// <summary>
        /// PUT api/Students/{id}; Update student
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
            int studentId = updateStudentCommandHandler.Handle(command);
            return Get(studentId);
        }

        /// <summary>
        /// PUT api/Students/{studentId}/Nationality/{NationalityId}
        /// Update student nationality
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nid"></param>
        /// <returns>Student with nationality</returns>
        [HttpPut("{id}/Nationality/{nid}")]
        public CitizenStudentDTO UpdateNationalityOfStudent(int id, int nid)
        {
            var command = new UpdateStudentNationalityCommand { StudentId = id, NationalityId = nid };
            int studentId = updateStudentNationalityCommandHandler.Handle(command);
            return GetCitizenStudent(id);
        }
        
        /// <summary>
        /// POST api/Students/5/FamilyMembers: Add family member
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
            int fmId = addFamilyMemberCommandHandler.Handle(command);

            return new FamilyMemberDTO { ID = fmId, FirstName = firstName, LastName = lastName, DateOfBirth = dob, RelationshipId = relationshipId }; 
            // No exception means data stored; So no need to fetch data that are already available
        }

        #endregion

        #region == Query == 

        /// <summary>
        /// GET: api/Students; Get all students
        /// </summary>
        /// <returns>List of StudentDTO</returns>
        [HttpGet]
        public IEnumerable<StudentDTO> Get()
        {
            var query = new GetAllStudentsQuery();
            return getAllStudentsQueryHandler.Handle(query);
        }

        /// <summary>
        /// GET api/Students/{id}/Nationality; Get student info with nationality
        /// </summary>
        /// <param name="id">Student id</param>
        /// <returns>List of Student with nationality</returns>
        [HttpGet("{id}/Nationality")]
        public CitizenStudentDTO GetCitizenStudent(int id)
        {
            var query = new GetStudentWithNationalityQuery() { StudentId = id };
            return getStudentWithNationalityQueryHandler.Handle(query);
        }

        /// <summary>
        /// GET api/Students/{id}/FamilyMembers; Get all family member of a student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/FamilyMembers")]
        public FamilyMemberDTO[] GetFamilyMembersOfStudent(int id)
        {
            var query = new GetStudentFamilyMembersQuery() { StudentId = id };
            return getStudentFamilyMembersQueryHandler.Handle(query);
        }

        // GET api/Students/5
        //[HttpGet("{id}")]
        private StudentDTO Get(int id)
        {
            var query = new GetStudentQuery() { StudentId = id };
            return getStudentQueryHandler.Handle(query);
        }

        #endregion
    }
}
