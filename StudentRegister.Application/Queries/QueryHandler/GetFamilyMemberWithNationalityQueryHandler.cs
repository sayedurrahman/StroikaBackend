using StudentRegister.Application.Queries.Interfaces;
using StudentRegister.DataAccess.Queries.Interfaces;
using StudentRegister.Models.DTOs;
using StudentRegister.Models.Queries;

namespace StudentRegister.Application.Queries.QueryHandler
{
    public class GetFamilyMemberWithNationalityQueryHandler : IQueryHandler<GetFamilyMemberWithNationalityQuery, CitizenFamilyMemberDTO>
    {
        private readonly IFamilyMemberQueryRepository familyMemberQueryRepository;

        public GetFamilyMemberWithNationalityQueryHandler(IFamilyMemberQueryRepository familyMemberQueryRepository)
        {
            this.familyMemberQueryRepository = familyMemberQueryRepository;
        }

        public CitizenFamilyMemberDTO Handle(GetFamilyMemberWithNationalityQuery t)
        {
            return familyMemberQueryRepository.GetFamilyMemberWithNationality(t);
        }
    }
}
