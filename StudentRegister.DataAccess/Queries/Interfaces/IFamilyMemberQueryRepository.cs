using StudentRegister.Models.DTOs;
using StudentRegister.Models.Queries;

namespace StudentRegister.DataAccess.Queries.Interfaces
{
    public interface IFamilyMemberQueryRepository
    {
        FamilyMemberDTO GetFamilyMember(GetFamilyMemberQuery query);
        CitizenFamilyMemberDTO GetFamilyMemberWithNationality(GetFamilyMemberWithNationalityQuery query);
    }
}
