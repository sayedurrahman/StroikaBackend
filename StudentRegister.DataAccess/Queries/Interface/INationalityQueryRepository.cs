using StudentRegister.Models.DTOs;

namespace StudentRegister.DataAccess.Queries.Interface
{
    public interface INationalityQueryRepository
    {
        IEnumerable<NationalityDTO> GetAll();
    }
}
