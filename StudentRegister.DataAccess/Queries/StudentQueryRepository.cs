using StudentRegister.DataAccess.Queries.Interface;
using StudentRegister.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.DataAccess.Queries
{
    public class StudentQueryRepository : IStudentQueryRepository
    {
        public StudentDTO[] GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public FamilyMemberDTO[] GetFamilyMembersOfAStudent(int studentId)
        {
            throw new NotImplementedException();
        }

        public CitizenStudentDTO GetStudentWithNationality(int studentId)
        {
            throw new NotImplementedException();
        }
    }
}
