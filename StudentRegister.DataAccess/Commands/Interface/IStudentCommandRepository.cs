using StudentRegister.Models.DTOs;

namespace StudentRegister.DataAccess.Commands.Interface
{
    public interface IStudentCommandRepository
    {
        bool AddStudent(StudentDTO student);
        bool UpdateStudent(int studentId, StudentDTO student);
        bool UpdateNationalityOfStudent(int studentId, int NationalityId);
        bool AddFamilyMemberOfStudent(int studentId, FamilyMemberDTO familyMember);
        
    }
}
