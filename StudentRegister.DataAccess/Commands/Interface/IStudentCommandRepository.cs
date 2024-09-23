using StudentRegister.Models.DTOs;

namespace StudentRegister.DataAccess.Commands.Interface
{
    public interface IStudentCommandRepository
    {
        void AddStudent(StudentDTO student);
        void AddFamilyMemberOfStudent(int studentId, FamilyMemberDTO familyMember);
        bool UpdateStudent(int studentId, StudentDTO student);
        bool UpdateNationalityOfStudent(int studentId, int NationalityId);        
    }
}
