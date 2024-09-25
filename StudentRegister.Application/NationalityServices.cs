using StudentRegister.Application.Queries.Interfaces;
using StudentRegister.Models.DTOs;
using StudentRegister.Models.Queries;

namespace StudentRegister.Application
{
    public class NationalityServices : INationalityServices
    {
        private readonly IQueryHandler<GetAllNationalitiesQuery, NationalityDTO[]> getAllNationalitiesQueryHandler;
        
        public NationalityServices(IQueryHandler<GetAllNationalitiesQuery, NationalityDTO[]> getAllNationalitiesQueryHandler)
        {
            this.getAllNationalitiesQueryHandler = getAllNationalitiesQueryHandler;
        }

        public IEnumerable<NationalityDTO> GetAllNationalities(GetAllNationalitiesQuery query)
        {
            return getAllNationalitiesQueryHandler.Handle(query);
        }
    }
}
