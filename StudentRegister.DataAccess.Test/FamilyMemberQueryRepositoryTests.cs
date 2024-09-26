using Microsoft.EntityFrameworkCore;
using StudentRegister.DataAccess.Queries;
using StudentRegister.Models.Entities;
using StudentRegister.Models.Queries;

namespace StudentRegister.DataAccess.Test
{
    public class FamilyMemberQueryRepositoryTests : IDisposable
    {
        private readonly StudentRegisterContext _context;
        private readonly FamilyMemberQueryRepository _repository;

        public FamilyMemberQueryRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<StudentRegisterContext>()
                      .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                      .Options;

            _context = new StudentRegisterContext(options);
            _repository = new FamilyMemberQueryRepository(_context);

            // Seed data for testing
            SeedData();
        }

        private void SeedData()
        {
            _context.FamilyMembers.AddRange(new List<FamilyMember>
            {
                new FamilyMember { ID = TestData.FamilyMember1.Id, StudentID = TestData.FamilyMember1.StudentID,  FirstName = TestData.FamilyMember1.FirstName, LastName = TestData.FamilyMember1.LastName, RelationshipId = TestData.FamilyMember1.RelationId, NationalityId = TestData.FamilyMember1.NationalityId },
                new FamilyMember { ID = TestData.FamilyMember2.Id, StudentID = TestData.FamilyMember2.StudentID,  FirstName = TestData.FamilyMember2.FirstName, LastName = TestData.FamilyMember2.LastName, RelationshipId = TestData.FamilyMember2.RelationId}
            });
            _context.SaveChanges();
        }


        [Fact]
        public void GetFamilyMember_ShouldReturnFamilyMemberDTO_WhenFamilyMemberExists()
        {
            // Arrange
            var query = new GetFamilyMemberQuery { Id = TestData.FamilyMember1.Id };

            // Act
            var result = _repository.GetFamilyMember(query);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(TestData.FamilyMember1.Id, result.ID);
            Assert.Equal(TestData.FamilyMember1.FirstName, result.FirstName);
            Assert.Equal(TestData.FamilyMember1.LastName, result.LastName);
            Assert.Equal(TestData.FamilyMember1.RelationId, result.RelationshipId);
        }

        [Fact]
        public void GetFamilyMember_ShouldThrowKeyNotFoundException_WhenFamilyMemberDoesNotExist()
        {
            // Arrange
            var query = new GetFamilyMemberQuery { Id = 999 };

            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() => _repository.GetFamilyMember(query));
        }

        [Fact]
        public void GetFamilyMemberWithNationality_ShouldReturnCitizenFamilyMemberDTO_WhenFamilyMemberExists()
        {
            // Arrange

            var query = new GetFamilyMemberWithNationalityQuery { Id = TestData.FamilyMember1.Id };

            // Act
            var result = _repository.GetFamilyMemberWithNationality(query);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(TestData.FamilyMember1.Id, result.ID);
            Assert.Equal(TestData.FamilyMember1.FirstName, result.FirstName);
            Assert.Equal(TestData.FamilyMember1.LastName, result.LastName);
            Assert.Equal(TestData.FamilyMember1.RelationId, result.RelationshipId);
            Assert.Equal(TestData.FamilyMember1.NationalityId, result.NationalityId);
        }

        [Fact]
        public void GetFamilyMemberWithNationality_ShouldReturnCitizenFamilyMemberDTOAndZeroNationality_WhenFamilyMemberExistsButNationalityNot()
        {
            // Arrange

            var query = new GetFamilyMemberWithNationalityQuery { Id = TestData.FamilyMember2.Id };

            // Act
            var result = _repository.GetFamilyMemberWithNationality(query);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(TestData.FamilyMember2.Id, result.ID);
            Assert.Equal(TestData.FamilyMember2.FirstName, result.FirstName);
            Assert.Equal(TestData.FamilyMember2.LastName, result.LastName);
            Assert.Equal(TestData.FamilyMember2.RelationId, result.RelationshipId);
            Assert.Equal(0, result.NationalityId);
        }

        [Fact]
        public void GetFamilyMemberWithNationality_ShouldThrowKeyNotFoundException_WhenFamilyMemberDoesNotExist()
        {
            // Arrange
            var query = new GetFamilyMemberWithNationalityQuery { Id = 999 };

            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() => _repository.GetFamilyMemberWithNationality(query));
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}