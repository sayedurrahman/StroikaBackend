using StudentRegister.Models.BaseModels;

namespace StudentRegister.Models
{
    public class FamilyMember: Person
    {
        public DateTime DateOfBirth { get; set; }
        public int RelationshipId { get; set; }
    }
}
