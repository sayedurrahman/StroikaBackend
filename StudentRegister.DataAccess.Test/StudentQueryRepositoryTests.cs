using Microsoft.EntityFrameworkCore;
using StudentRegister.DataAccess.Queries;
using StudentRegister.Models.Entities;

namespace StudentRegister.DataAccess.Test
{
    public class StudentQueryRepositoryTests : IDisposable
    {
        private readonly StudentRegisterContext _context;
        private readonly StudentQueryRepository _repository;

        public StudentQueryRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<StudentRegisterContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new StudentRegisterContext(options);
            _repository = new StudentQueryRepository(_context);

            // Seed test data
            SeedData();
        }

        private void SeedData()
        {
            var students = new List<Student>
            {
                new Student { ID = TestData.Student1.Id , FirstName = TestData.Student1.FirstName, LastName = TestData.Student1.LastName, NationalityId=TestData.Student1.NationalityId, DateOfBirth = new DateTime(2000, 1, 1) },
                new Student { ID = TestData.Student2.Id , FirstName = TestData.Student2.FirstName, LastName = TestData.Student2.LastName, NationalityId=TestData.Student2.NationalityId, DateOfBirth = new DateTime(1998, 6, 15) }
             };

            var familyMembers = new List<FamilyMember>
            {
                new FamilyMember { ID = TestData.FamilyMember1.Id, StudentID = TestData.FamilyMember1.StudentID,  FirstName = TestData.FamilyMember1.FirstName, LastName = TestData.FamilyMember1.LastName, RelationshipId = TestData.FamilyMember1.RelationId, NationalityId = TestData.FamilyMember1.NationalityId },
                new FamilyMember { ID = TestData.FamilyMember2.Id, StudentID = TestData.FamilyMember2.StudentID,  FirstName = TestData.FamilyMember2.FirstName, LastName = TestData.FamilyMember2.LastName, RelationshipId = TestData.FamilyMember2.RelationId}
             };

            _context.Students.AddRange(students);
            _context.FamilyMembers.AddRange(familyMembers);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Fact]
        public void GetAllStudents_ShouldReturnAllStudents()
        {
            // Act
            var result = _repository.GetAllStudents();

            // Assert
            Assert.Equal(2, result.Length);
            Assert.Contains(result, s => s.FirstName == TestData.Student1.FirstName && s.LastName == TestData.Student1.LastName);
            Assert.Contains(result, s => s.FirstName == TestData.Student2.FirstName && s.LastName == TestData.Student2.LastName);
        }

        [Fact]
        public void GetAStudent_ShouldReturnStudent_WhenStudentExists()
        {
            // Act
            var result = _repository.GetAStudent(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(TestData.Student1.FirstName, result.FirstName);
            Assert.Equal(TestData.Student1.LastName, result.LastName);
        }

        [Fact]
        public void GetAStudent_ShouldThrowException_WhenStudentDoesNotExist()
        {
            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() => _repository.GetAStudent(999));
        }

        [Fact]
        public void GetFamilyMembersOfAStudent_ShouldReturnFamilyMembers_WhenStudentExists()
        {
            // Act
            var result = _repository.GetFamilyMembersOfAStudent(TestData.Student1.Id);

            // Assert
            Assert.Equal(1, result.Length);
            Assert.Contains(result, fm => fm.FirstName == TestData.FamilyMember1.FirstName);
        }

        [Fact]
        public void GetFamilyMembersOfAStudent_ShouldReturnEmptyArray_WhenNoFamilyMembersExist()
        {
            // Act
            var result = _repository.GetFamilyMembersOfAStudent(999);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void GetStudentWithNationality_ShouldReturnStudentWithNationality_WhenStudentExists()
        {
            // Act
            var result = _repository.GetStudentWithNationality(TestData.Student1.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(TestData.Student1.FirstName, result.FirstName);
            Assert.Equal(TestData.Student1.LastName, result.LastName);
            Assert.Equal(TestData.Student1.NationalityId, result.NationalityId);
        }

        [Fact]
        public void GetStudentWithNationality_ShouldThrowException_WhenStudentDoesNotExist()
        {
            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() => _repository.GetStudentWithNationality(999));
        }
    }
}
