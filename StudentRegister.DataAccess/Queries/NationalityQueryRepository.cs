using StudentRegister.DataAccess.Queries.Interfaces;
using StudentRegister.Models.DTOs;

namespace StudentRegister.DataAccess.Queries
{
    public class NationalityQueryRepository : INationalityQueryRepository
    {
        public StudentRegisterContext _studentRegisterContext { get; }

        public NationalityQueryRepository(StudentRegisterContext studentRegisterContext)
        {
            _studentRegisterContext = studentRegisterContext;
        }

        /// <summary>
        /// Get all nationalities
        /// </summary>
        /// <returns>Array of nationalities</returns>
        public NationalityDTO[] GetAll()
        {
            return _studentRegisterContext.Nationalities.Select(x => new NationalityDTO(x)).ToArray();
        }
    }
}
