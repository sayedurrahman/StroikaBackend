using StudentRegister.Models.Commands;
using StudentRegister.Models.DTOs;
using StudentRegister.Models.Queries;

namespace StudentRegister.Application
{
    public interface IFamilyMemberService
    {
        FamilyMemberDTO AddStudentFamilyMember(AddFamilyMemberCommand command);
        FamilyMemberDTO UpdateFamilyMember(UpdateFamilyMemberCommand command);
        void DeleteFamilyMember(DeleteFamilyMemberCommand command);
        CitizenFamilyMemberDTO UpdateFamilyMemberNationality(UpdateFamilyMemberNationalityCommand command);
        CitizenFamilyMemberDTO GetFamilyMemberWithNationality(GetFamilyMemberWithNationalityQuery query);
    }
}
