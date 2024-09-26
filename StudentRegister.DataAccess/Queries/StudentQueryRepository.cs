using StudentRegister.DataAccess.Queries.Interfaces;
using StudentRegister.Models.DTOs;

namespace StudentRegister.DataAccess.Queries
{
    public class StudentQueryRepository : IStudentQueryRepository
    {
        public StudentRegisterContext _context { get; }
        public StudentQueryRepository(StudentRegisterContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all students
        /// </summary>
        /// <returns>Array of studentsDTO</returns>
        public StudentDTO[] GetAllStudents()
        {
            return _context.Students.Select(x => new StudentDTO(x)).ToArray();
        }

        /// <summary>
        /// Get a student
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns>StudentDTO</returns>
        /// <exception cref="KeyNotFoundException">If student cannot be found by the Id</exception>
        public StudentDTO GetAStudent(int studentId)
        {
            var student = _context.Students.Find(studentId);
            if (student == null)
                throw new KeyNotFoundException();

            return new StudentDTO(student);
        }

        /// <summary>
        /// Get all family members of a student
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns>Array of family members</returns>
        public FamilyMemberDTO[] GetFamilyMembersOfAStudent(int studentId)
        {
            return _context.FamilyMembers.Where(x => x.StudentID == studentId).Select(x => new FamilyMemberDTO(x)).ToArray();
        }

        /// <summary>
        /// Get a student with nationality
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns>Student with nationality</returns>
        /// <exception cref="KeyNotFoundException">If student cannot be found by the Id</exception>
        public CitizenStudentDTO GetStudentWithNationality(int studentId)
        {
            var student = _context.Students.Find(studentId);
            if (student == null)
                throw new KeyNotFoundException();

            return new CitizenStudentDTO(student);
        }
    }
}
