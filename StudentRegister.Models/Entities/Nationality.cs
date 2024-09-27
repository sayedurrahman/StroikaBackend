namespace StudentRegister.Models.Entities
{
    public class Nationality
    {
        public int Id { get; set; }
        public string NationalityName { get; set; }
        public string Country { get; set; }
        public string Alpha2Code { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
