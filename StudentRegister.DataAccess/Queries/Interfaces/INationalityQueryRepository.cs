using StudentRegister.Models.DTOs;

namespace StudentRegister.DataAccess.Queries.Interfaces
{
    public interface INationalityQueryRepository
    {
        IEnumerable<NationalityDTO> GetAll();
    }
}
