using StudentRegister.Application.Queries.Interfaces;
using StudentRegister.DataAccess.Queries.Interfaces;
using StudentRegister.Models.DTOs;
using StudentRegister.Models.Queries;

namespace StudentRegister.Application.Queries.QueryHandler
{
    public class GetFamilyMemberQueryHandler : IQueryHandler<GetFamilyMemberQuery, FamilyMemberDTO>
    {
        private readonly IFamilyMemberQueryRepository familyMemberQueryRepository;

        public GetFamilyMemberQueryHandler(IFamilyMemberQueryRepository familyMemberQueryRepository)
        {
            this.familyMemberQueryRepository = familyMemberQueryRepository;
        }

        public FamilyMemberDTO Handle(GetFamilyMemberQuery t)
        {
            return familyMemberQueryRepository.GetFamilyMember(t);
        }
    }
}
