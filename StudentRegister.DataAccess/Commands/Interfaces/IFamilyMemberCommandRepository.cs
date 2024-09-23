using StudentRegister.Models.DTOs;

namespace StudentRegister.DataAccess.Commands.Interfaces
{
    public interface IFamilyMemberCommandRepository
    {
        bool UpdateFamilyMember(int familyMemberId, FamilyMemberDTO member);
        void DeleteFamilyMember(int familyMemberId);
        bool UpdateNationalityOfAFamilyMember(int familyMemberId, int newNationalityId);
    }
}
