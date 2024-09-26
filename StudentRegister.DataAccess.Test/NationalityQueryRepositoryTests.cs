using Microsoft.EntityFrameworkCore;
using StudentRegister.DataAccess.Queries;
using StudentRegister.Models.Entities;

namespace StudentRegister.DataAccess.Test
{
    public class NationalityQueryRepositoryTests : IDisposable
    {
        private readonly StudentRegisterContext _context;
        private readonly NationalityQueryRepository _repository;

        public NationalityQueryRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<StudentRegisterContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new StudentRegisterContext(options);
            _repository = new NationalityQueryRepository(_context);

            // Seed test data
            SeedData();
        }

        private void SeedData()
        {
            var Nationalities = new List<Nationality>
            {
                new Nationality { Id = TestData.Nationality1.Id , Country = TestData.Nationality1.Country, NationalityName = TestData.Nationality1.NationalityName, Alpha2Code=TestData.Nationality1.Alpha2Code },
                new Nationality { Id = TestData.Nationality2.Id , Country = TestData.Nationality2.Country, NationalityName = TestData.Nationality2.NationalityName, Alpha2Code=TestData.Nationality2.Alpha2Code },
                new Nationality { Id = TestData.Nationality3.Id , Country = TestData.Nationality3.Country, NationalityName = TestData.Nationality3.NationalityName, Alpha2Code=TestData.Nationality3.Alpha2Code }
             };

            _context.Nationalities.AddRange(Nationalities);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Fact]
        public void GetAllNationalities_ShouldReturnAllNationalities()
        {
            // Act
            var result = _repository.GetAll();

            // Assert
            Assert.Equal(3, result.Length);
            Assert.Contains(result, s => s.AlphaCode == TestData.Nationality1.Alpha2Code && s.Country == TestData.Nationality1.Country && s.Name == TestData.Nationality1.NationalityName);
            Assert.Contains(result, s => s.AlphaCode == TestData.Nationality2.Alpha2Code && s.Country == TestData.Nationality2.Country && s.Name == TestData.Nationality2.NationalityName);
            Assert.Contains(result, s => s.AlphaCode == TestData.Nationality3.Alpha2Code && s.Country == TestData.Nationality3.Country && s.Name == TestData.Nationality3.NationalityName);
        }
    }
}
