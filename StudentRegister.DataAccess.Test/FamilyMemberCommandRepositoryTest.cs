using Microsoft.EntityFrameworkCore;
using StudentRegister.DataAccess.Commands;
using StudentRegister.Models.Commands;
using StudentRegister.Models.Entities;

namespace StudentRegister.DataAccess.Test
{
    public class FamilyMemberCommandRepositoryTest : IDisposable
    {
        private readonly StudentRegisterContext _context;
        private readonly FamilyMemberCommandRepository _repository;
        public FamilyMemberCommandRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<StudentRegisterContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            _context = new StudentRegisterContext(options);
            _repository = new FamilyMemberCommandRepository(_context);
            SeedData();
        }

        private void SeedData()
        {
            var student = new Student { ID = TestData.Student1.Id, FirstName = TestData.Student1.FirstName, LastName = TestData.Student1.LastName, NationalityId = TestData.Student1.NationalityId, DateOfBirth = new DateTime(2000, 1, 1) };
            var familyMember = new FamilyMember { ID = TestData.FamilyMember1.Id, StudentID = TestData.FamilyMember1.StudentID, FirstName = TestData.FamilyMember1.FirstName, LastName = TestData.FamilyMember1.LastName, RelationshipId = TestData.FamilyMember1.RelationId, NationalityId = TestData.FamilyMember1.NationalityId };
            _context.Students.Add(student);
            _context.FamilyMembers.Add(familyMember);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Fact]
        public void AddFamilyMemberOfStudent_InputFamilyMemberInfo_ShouldAddFamilyMemberSuccessfully()
        {
            // Arrange
            var command = new AddFamilyMemberCommand
            {
                StudentId = TestData.FamilyMember11.StudentID,
                FirstName = TestData.FamilyMember11.FirstName,
                LastName = TestData.FamilyMember11.LastName,
                RelationshipId = TestData.FamilyMember11.RelationId,
                DateOfBirth = new DateTime(1990, 1, 1)
            };

            // Act
            var familyMemberId = _repository.AddFamilyMemberOfStudent(command);

            // Assert
            var addedFamilyMember = _context.FamilyMembers.Find(familyMemberId);
            Assert.NotNull(addedFamilyMember);
            Assert.Equal(TestData.FamilyMember11.FirstName, addedFamilyMember.FirstName);
            Assert.Equal(TestData.FamilyMember11.LastName, addedFamilyMember.LastName);
            Assert.Equal(TestData.FamilyMember11.RelationId, addedFamilyMember.RelationshipId);
            Assert.Equal(new DateTime(1990, 1, 1), addedFamilyMember.DateOfBirth);
        }

        [Fact]
        public void DeleteFamilyMember_InputFamilyMemberId_ShouldRemoveFamilyMember_WhenFamilyMemberExists()
        {
            // Arrange
            var command = new DeleteFamilyMemberCommand { FamilyMemberId = 1 };

            // Act
            _repository.DeleteFamilyMember(command);

            // Assert
            var deletedFamilyMember = _context.FamilyMembers.Find(1);
            Assert.Null(deletedFamilyMember);
        }

        [Fact]
        public void UpdateFamilyMember_InputFamilyMemberInfo_ShouldUpdateFamilyMemberDetails_WhenFamilyMemberExists()
        {
            // Arrange
            var command = new UpdateFamilyMemberCommand
            {
                Id = 1,
                FirstName = TestData.FamilyMember11.FirstName,
                LastName = TestData.FamilyMember11.LastName,
                RelationshipId = TestData.FamilyMember11.RelationId,
                DateOfBirth = new DateTime(1970, 1, 1)
            };

            // Act
            var resultId = _repository.UpdateFamilyMember(command);

            // Assert
            var updatedFamilyMember = _context.FamilyMembers.Find(resultId);
            Assert.NotNull(updatedFamilyMember);
            Assert.Equal(TestData.FamilyMember11.FirstName, updatedFamilyMember.FirstName);
            Assert.Equal(TestData.FamilyMember11.LastName, updatedFamilyMember.LastName);
            Assert.Equal(TestData.FamilyMember11.RelationId, updatedFamilyMember.RelationshipId);
            Assert.Equal(new DateTime(1970, 1, 1), updatedFamilyMember.DateOfBirth);
        }

        [Fact]
        public void UpdateFamilyMember_InputNonExistentFMID_ShouldReturnZero_WhenFamilyMemberDoesNotExist()
        {
            // Arrange
            var command = new UpdateFamilyMemberCommand
            {
                Id = 999, // Non-existent ID
                FirstName = "Non",
                LastName = "Existent",
                RelationshipId = 3,
                DateOfBirth = new DateTime(1970, 1, 1)
            };

            // Act
            var resultId = _repository.UpdateFamilyMember(command);

            // Assert
            Assert.Equal(0, resultId);
        }

        [Fact]
        public void UpdateNationalityOfAFamilyMember_InputFMIdNewNationalityId_ShouldUpdateNationality_WhenFamilyMemberExists()
        {
            // Arrange
            var command = new UpdateFamilyMemberNationalityCommand
            {
                FamilyMemberId = TestData.FamilyMember1.Id,
                NewNationalityId = 5
            };

            // Act
            var resultId = _repository.UpdateNationalityOfAFamilyMember(command);

            // Assert
            var updatedFamilyMember = _context.FamilyMembers.Find(resultId);
            Assert.NotNull(updatedFamilyMember);
            Assert.Equal(5, updatedFamilyMember.NationalityId);
        }

        [Fact]
        public void UpdateNationalityOfAFamilyMember_InputNonExistentFMID_ShouldReturnZero_WhenFamilyMemberDoesNotExist()
        {
            // Arrange
            var command = new UpdateFamilyMemberNationalityCommand
            {
                FamilyMemberId = 999, // Non-existent ID
                NewNationalityId = 5
            };

            // Act
            var resultId = _repository.UpdateNationalityOfAFamilyMember(command);

            // Assert
            Assert.Equal(0, resultId);
        }
    }
}
