using StudentRegister.DataAccess.Commands.Interface;
using StudentRegister.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.DataAccess.Commands
{
    public class StudentCommandRepository : IStudentCommandRepository
    {
        public bool AddFamilyMemberOfStudent(int studentId, FamilyMemberDTO familyMember)
        {
            throw new NotImplementedException();
        }

        public bool AddStudent(StudentDTO student)
        {
            throw new NotImplementedException();
        }

        public bool UpdateNationalityOfStudent(int studentId, int NationalityId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateStudent(int studentId, StudentDTO student)
        {
            throw new NotImplementedException();
        }
    }
}
