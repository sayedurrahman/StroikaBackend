namespace StudentRegister.Models.Commands
{
    public class UpdateFamilyMemberNationalityCommand
    {
        public int FamilyMemberId { get; set; }
        public int NewNationalityId { get; set; }
    }
}
