namespace StudentRegister.Models.Commands
{
    public class AddStudentCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
