using StudentRegister.Models.DTOs;
using StudentRegister.Models.Queries;

namespace StudentRegister.Application
{
    public interface INationalityServices
    {
        IEnumerable<NationalityDTO> GetAllNationalities(GetAllNationalitiesQuery query);
    }
}
