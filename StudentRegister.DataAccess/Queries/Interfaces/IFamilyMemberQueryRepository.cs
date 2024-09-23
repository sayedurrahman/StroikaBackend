using StudentRegister.Models.DTOs;

namespace StudentRegister.DataAccess.Queries.Interfaces
{
    public interface IFamilyMemberQueryRepository
    {
        FamilyMemberDTO GetFamilyMember(int id);
        CitizenFamilyMemberDTO GetFamilyMemberWithNationality(int id);
    }
}
