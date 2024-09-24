using StudentRegister.Models.DTOs;

namespace StudentRegister.DataAccess.Queries.Interfaces
{
    public interface IStudentQueryRepository
    {
        StudentDTO[] GetAllStudents();
        StudentDTO GetAStudent(int studentId);
        CitizenStudentDTO GetStudentWithNationality(int studentId);
        FamilyMemberDTO[] GetFamilyMembersOfAStudent(int studentId);
    }
}
