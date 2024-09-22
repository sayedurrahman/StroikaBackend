using StudentRegister.Models.DTOs;

namespace StudentRegister.DataAccess.Queries
{
    public interface INationalityQueryRepository
    {
        IEnumerable<NationalityDTO> GetAll();
    }
}
