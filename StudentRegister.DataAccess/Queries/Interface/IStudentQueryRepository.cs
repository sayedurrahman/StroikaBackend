using StudentRegister.Models.DTOs;

namespace StudentRegister.DataAccess.Queries.Interface
{
    public interface IStudentQueryRepository
    {
        StudentDTO[] GetAllStudents();
        CitizenStudentDTO GetStudentWithNationality(int studentId);
        FamilyMemberDTO[] GetFamilyMembersOfAStudent(int studentId);
    }
}
