using StudentRegister.Application.Queries.Interfaces;
using StudentRegister.DataAccess.Queries.Interfaces;
using StudentRegister.Models.DTOs;
using StudentRegister.Models.Queries;

namespace StudentRegister.Application.Queries.QueryHandler
{
    public class GetAllNationalitiesQueryHandler : IQueryHandler<GetAllNationalitiesQuery, NationalityDTO[]>
    {
        private readonly INationalityQueryRepository nationalityQueryRepository;

        public GetAllNationalitiesQueryHandler(INationalityQueryRepository nationalityQueryRepository)
        {
            this.nationalityQueryRepository = nationalityQueryRepository;
        }

        public NationalityDTO[] Handle(GetAllNationalitiesQuery t)
        {
            return nationalityQueryRepository.GetAll();
        }
    }
}
