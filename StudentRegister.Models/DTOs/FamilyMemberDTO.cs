using StudentRegister.Models.BaseModels;
using StudentRegister.Models.Entities;

namespace StudentRegister.Models.DTOs
{
    public class FamilyMemberDTO : Person
    {
        public FamilyMemberDTO() { }
        public FamilyMemberDTO(FamilyMember fm)
        {
            ID = fm.ID;
            FirstName = fm.FirstName;
            LastName = fm.LastName;
            DateOfBirth = fm.DateOfBirth;
            RelationshipId = fm.RelationshipId;
        }

        public DateTime DateOfBirth { get; set; }
        public int RelationshipId { get; set; }
    }
}
