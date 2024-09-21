using StudentRegister.Models.BaseModels;

namespace StudentRegister.Models.DTOs
{
    public class CitizenFamilyMemberDTO : Citizen
    {
        public DateTime DateOfBirth { get; set; }
        public int RelationshipId { get; set; }
    }
}
