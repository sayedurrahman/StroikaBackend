using StudentRegister.Models.BaseModels;

namespace StudentRegister.Models
{
    public class CitizenFamilyMember: Citizen
    {
        public DateTime DateOfBirth { get; set; }
        public int RelationshipId { get; set; }
    }
}
