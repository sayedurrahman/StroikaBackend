using StudentRegister.Models.BaseModels;
using StudentRegister.Models.Entities;

namespace StudentRegister.Models.DTOs
{
    public class CitizenFamilyMemberDTO : Citizen
    {
        public CitizenFamilyMemberDTO(FamilyMember fm)
        {
            ID = fm.ID;
            FirstName = fm.FirstName;
            LastName = fm.LastName;
            DateOfBirth = fm.DateOfBirth;
            RelationshipId = fm.RelationshipId;
            NationalityId = fm.NationalityId.HasValue ? fm.NationalityId.Value : 0;
        }

        public DateTime DateOfBirth { get; set; }
        public int RelationshipId { get; set; }
    }
}
