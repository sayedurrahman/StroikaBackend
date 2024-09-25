using StudentRegister.Models.Commands;
using StudentRegister.Models.DTOs;
using StudentRegister.Models.Queries;

namespace StudentRegister.Application
{
    public interface IStudentServices
    {
        StudentDTO AddStudent(AddStudentCommand command);
        StudentDTO UpdateStudent(UpdateStudentCommand command);
        CitizenStudentDTO UpdateStudentNationality(UpdateStudentNationalityCommand command);
        IEnumerable<StudentDTO> GetAllStudents(GetAllStudentsQuery query);
        CitizenStudentDTO GetStudentWithNationality(GetStudentWithNationalityQuery query);
        FamilyMemberDTO[] GetStudentFamilyMembers(GetStudentFamilyMembersQuery query);
    }
}
