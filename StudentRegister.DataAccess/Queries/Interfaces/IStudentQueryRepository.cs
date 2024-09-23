using StudentRegister.Models.DTOs;

namespace StudentRegister.DataAccess.Queries.Interfaces
{
    public interface IStudentQueryRepository
    {
        StudentDTO[] GetAllStudents();
        CitizenStudentDTO GetStudentWithNationality(int studentId);
        FamilyMemberDTO[] GetFamilyMembersOfAStudent(int studentId);
    }
}
