using StudentRegister.Application.Commands.Interfaces;
using StudentRegister.Application.Queries.Interfaces;
using StudentRegister.Models.Commands;
using StudentRegister.Models.DTOs;
using StudentRegister.Models.Queries;

namespace StudentRegister.Application
{
    public class StudentServices : IStudentServices
    {
        private readonly ICommandHandler<AddStudentCommand> addStudentCommandHandler;
        private readonly ICommandHandler<UpdateStudentCommand> updateStudentCommandHandler;
        private readonly ICommandHandler<UpdateStudentNationalityCommand> updateStudentNationalityCommandHandler;
        private readonly ICommandHandler<AddFamilyMemberCommand> addFamilyMemberCommandHandler;
        private readonly IQueryHandler<GetAllStudentsQuery, StudentDTO[]> getAllStudentsQueryHandler;
        private readonly IQueryHandler<GetStudentQuery, StudentDTO> getStudentQueryHandler;
        private readonly IQueryHandler<GetStudentWithNationalityQuery, CitizenStudentDTO> getStudentWithNationalityQueryHandler;
        private readonly IQueryHandler<GetStudentFamilyMembersQuery, FamilyMemberDTO[]> getStudentFamilyMembersQueryHandler;

        public StudentServices(ICommandHandler<AddStudentCommand> addStudentCommandHandler,
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

        public StudentDTO AddStudent(AddStudentCommand command)
        {
            int studentId = addStudentCommandHandler.Handle(command);
            return GetStudentById(studentId);
        }

        public StudentDTO UpdateStudent(UpdateStudentCommand command)
        {
            int studentId = updateStudentCommandHandler.Handle(command);
            return GetStudentById(studentId);
        }

        public CitizenStudentDTO UpdateStudentNationality(UpdateStudentNationalityCommand command)
        {
            int studentId = updateStudentNationalityCommandHandler.Handle(command);
            return getStudentWithNationalityQueryHandler.Handle(new() { StudentId = studentId });
        }

        public FamilyMemberDTO AddStudentFamilyMember(AddFamilyMemberCommand command)
        {
            //int fmId = addFamilyMemberCommandHandler.Handle(command);
            return null;
        }

        #endregion

        #region == Query == 

        public IEnumerable<StudentDTO> GetAllStudents(GetAllStudentsQuery query)
        {
            return getAllStudentsQueryHandler.Handle(query);
        }

        public CitizenStudentDTO GetStudentWithNationality(GetStudentWithNationalityQuery query)
        {
            return getStudentWithNationalityQueryHandler.Handle(query);
        }

        public FamilyMemberDTO[] GetStudentFamilyMembers(GetStudentFamilyMembersQuery query)
        {
            return getStudentFamilyMembersQueryHandler.Handle(query);
        }

        #endregion

        private StudentDTO GetStudentById(int id)
        {
            var query = new GetStudentQuery() { StudentId = id };
            return getStudentQueryHandler.Handle(query);
        }
    }
}
