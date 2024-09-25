using StudentRegister.Models.Commands;

namespace StudentRegister.DataAccess.Commands.Interfaces
{
    public interface IFamilyMemberCommandRepository
    {
        int AddFamilyMemberOfStudent(AddFamilyMemberCommand familyMember);
        int UpdateFamilyMember(UpdateFamilyMemberCommand command);
        void DeleteFamilyMember(DeleteFamilyMemberCommand command);
        int UpdateNationalityOfAFamilyMember(UpdateFamilyMemberNationalityCommand command);
    }
}
