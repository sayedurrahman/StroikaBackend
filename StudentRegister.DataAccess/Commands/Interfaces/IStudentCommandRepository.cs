using StudentRegister.Models.Commands;
using StudentRegister.Models.DTOs;

namespace StudentRegister.DataAccess.Commands.Interfaces
{
    public interface IStudentCommandRepository
    {
        int AddStudent(AddStudentCommand student);
        void AddFamilyMemberOfStudent(int studentId, FamilyMemberDTO familyMember);
        bool UpdateStudent(int studentId, StudentDTO student);
        bool UpdateNationalityOfStudent(int studentId, int NationalityId);        
    }
}
