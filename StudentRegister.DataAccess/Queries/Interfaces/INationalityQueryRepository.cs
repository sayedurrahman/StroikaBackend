using StudentRegister.Models.DTOs;

namespace StudentRegister.DataAccess.Queries.Interfaces
{
    public interface INationalityQueryRepository
    {
        NationalityDTO[] GetAll();
    }
}
