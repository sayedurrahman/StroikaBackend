namespace StudentRegister.Models.Entities
{
    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int NationalityId { get; set; }
        public Nationality Nationality { get; set; }
        public ICollection<FamilyMember> FamilyMembers { get; set; }
    }
}
