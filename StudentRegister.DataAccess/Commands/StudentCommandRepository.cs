using StudentRegister.DataAccess.Commands.Interfaces;
using StudentRegister.Models.Commands;
using StudentRegister.Models.DTOs;
using StudentRegister.Models.Entities;

namespace StudentRegister.DataAccess.Commands
{
    public class StudentCommandRepository : IStudentCommandRepository
    {
        private readonly StudentRegisterContext context;

        public StudentCommandRepository(StudentRegisterContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Adds a new student
        /// </summary>
        /// <param name="student"></param>
        /// <returns>New student Id</returns>
        public int AddStudent(AddStudentCommand student)
        {
            Student s = new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                AddedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                FamilyMembers = new List<FamilyMember>()
            };
            context.Students.Add(s);
            context.SaveChanges();
            return s.ID;
        }

        public void AddFamilyMemberOfStudent(int studentId, FamilyMemberDTO familyMember)
        {
            context.FamilyMembers.Add(new FamilyMember
            {
                StudentID = studentId,
                FirstName = familyMember.FirstName,
                LastName = familyMember.LastName,
                RelationshipId = familyMember.RelationshipId,
                DateOfBirth = familyMember.DateOfBirth,
                AddedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
            });
            context.SaveChanges();
        }

        public bool UpdateNationalityOfStudent(int studentId, int nationalityId)
        {
            var student = context.Students.Find(studentId);
            if (student == null)
                throw new KeyNotFoundException();

            student.NationalityId = nationalityId;
            context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Updates student info
        /// </summary>
        /// <param name="stu">Student</param>
        /// <returns>Student Id</returns>
        /// <exception cref="KeyNotFoundException">If student cannot be found by the Id</exception>
        public int UpdateStudent(UpdateStudentCommand stu)
        {
            var student = context.Students.Find(stu.Id);
            if (student == null)
                throw new KeyNotFoundException();

            student.FirstName = stu.FirstName;
            student.LastName = stu.LastName;
            student.DateOfBirth = stu.DateOfBirth;
            student.UpdatedOn = DateTime.Now;
            context.SaveChanges();
            return student.ID;
        }
    }
}
