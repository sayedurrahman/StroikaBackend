using StudentRegister.DataAccess.Commands.Interfaces;
using StudentRegister.Models.Commands;
using StudentRegister.Models.DTOs;
using StudentRegister.Models.Entities;

namespace StudentRegister.DataAccess.Commands
{
    public class StudentCommandRepository : IStudentCommandRepository
    {
        public StudentRegisterContext _context { get; }
        public StudentCommandRepository(StudentRegisterContext context)
        {
            _context = context;
        }
        
        public void AddStudent(AddStudentCommand student)
        {
            _context.Students.Add(new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                AddedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                FamilyMembers = new List<FamilyMember>()
            });
            _context.SaveChanges();
        }

        public void AddFamilyMemberOfStudent(int studentId, FamilyMemberDTO familyMember)
        {
            _context.FamilyMembers.Add(new FamilyMember
            {
                StudentID = studentId,
                FirstName = familyMember.FirstName,
                LastName = familyMember.LastName,
                RelationshipId = familyMember.RelationshipId,
                DateOfBirth = familyMember.DateOfBirth,
                AddedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
            });
            _context.SaveChanges();
        }

        public bool UpdateNationalityOfStudent(int studentId, int nationalityId)
        {
            var student = _context.Students.Find(studentId);
            if (student == null)
                throw new KeyNotFoundException();

            student.NationalityId = nationalityId;
            _context.SaveChanges();
            return true;
        }

        public bool UpdateStudent(int studentId, StudentDTO stu)
        {
            var student = _context.Students.Find(studentId);
            if (student == null)
                throw new KeyNotFoundException();

            student.FirstName = stu.FirstName;
            student.LastName = stu.LastName;
            student.DateOfBirth = stu.DateOfBirth;
            _context.SaveChanges();
            return true;
        }
    }
}
