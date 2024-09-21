using StudentRegister.Models.BaseModels;

namespace StudentRegister.Models.DTOs
{
    public class FamilyMemberDTO : Person
    {
        public DateTime DateOfBirth { get; set; }
        public int RelationshipId { get; set; }
    }
}
