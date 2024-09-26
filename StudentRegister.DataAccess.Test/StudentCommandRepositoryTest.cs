using Microsoft.EntityFrameworkCore;
using StudentRegister.DataAccess.Commands;
using StudentRegister.Models.Commands;
using StudentRegister.Models.Entities;

namespace StudentRegister.DataAccess.Test
{
    public class StudentCommandRepositoryTest : IDisposable
    {
        private readonly StudentRegisterContext _context;
        private readonly StudentCommandRepository _repository;
        public StudentCommandRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<StudentRegisterContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            _context = new StudentRegisterContext(options);
            _repository = new StudentCommandRepository(_context);
            SeedData();
        }

        private void SeedData()
        {
            var student = new Student { ID = TestData.Student1.Id, FirstName = TestData.Student1.FirstName, LastName = TestData.Student1.LastName, NationalityId = TestData.Student1.NationalityId, DateOfBirth = new DateTime(2000, 1, 1) };
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Fact]
        public void AddStudent_ShouldAddStudentSuccessfully()
        {
            // Arrange
            var command = new AddStudentCommand { FirstName = TestData.Student2.FirstName, LastName = TestData.Student2.LastName, DateOfBirth = new DateTime(2002, 5, 10) };

            // Act
            var studentId = _repository.AddStudent(command);

            // Assert
            var addedStudent = _context.Students.Find(studentId);
            Assert.NotNull(addedStudent);
            Assert.Equal(TestData.Student2.FirstName, addedStudent.FirstName);
            Assert.Equal(TestData.Student2.LastName, addedStudent.LastName);
            Assert.Equal(new DateTime(2002, 5, 10), addedStudent.DateOfBirth);
        }

        [Fact]
        public void UpdateNationalityOfStudent_InputStudentIdAndNewNationalityId_ShouldUpdateNationality_WhenStudentExists()
        {
            // Arrange
            var command = new UpdateStudentNationalityCommand
            {
                StudentId = TestData.Student1.Id,
                NationalityId = 3 // New nationality
            };

            // Act
            var resultId = _repository.UpdateNationalityOfStudent(command);

            // Assert
            var updatedStudent = _context.Students.Find(resultId);
            Assert.NotNull(updatedStudent);
            Assert.Equal(3, updatedStudent.NationalityId);
        }

        [Fact]
        public void UpdateNationalityOfStudent_InputNonExistentStudentId_ShouldThrowException_WhenStudentDoesNotExist()
        {
            // Arrange
            var command = new UpdateStudentNationalityCommand
            {
                StudentId = 999, // Non-existent ID
                NationalityId = 3
            };

            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() => _repository.UpdateNationalityOfStudent(command));
        }

        [Fact]
        public void UpdateStudent_InputStudentInfo_ShouldUpdateStudentDetails_WhenStudentExists()
        {
            // Arrange
            var command = new UpdateStudentCommand
            {
                Id = TestData.Student1.Id, // Existing student ID
                FirstName = TestData.Student1.FirstName,
                LastName = TestData.Student2.LastName,  // Student2 Last name
                DateOfBirth = new DateTime(2001, 1, 1)
            };

            // Act
            var resultId = _repository.UpdateStudent(command);

            // Assert
            var updatedStudent = _context.Students.Find(resultId);
            Assert.NotNull(updatedStudent);
            Assert.Equal(TestData.Student1.FirstName, updatedStudent.FirstName);
            Assert.Equal(TestData.Student2.LastName, updatedStudent.LastName);
            Assert.Equal(new DateTime(2001, 1, 1), updatedStudent.DateOfBirth);
        }

        [Fact]
        public void UpdateStudent_InputNonExistentStudentId_ShouldThrowException_WhenStudentDoesNotExist()
        {
            // Arrange
            var command = new UpdateStudentCommand
            {
                Id = 999, // Non-existent ID
                FirstName = "Non",
                LastName = "Existent",
                DateOfBirth = new DateTime(2000, 1, 1)
            };

            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() => _repository.UpdateStudent(command));
        }
    }
}
