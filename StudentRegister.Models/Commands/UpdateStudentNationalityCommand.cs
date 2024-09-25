namespace StudentRegister.Models.Commands
{
    public class UpdateStudentNationalityCommand
    {
        public int StudentId { get; set; }
        public int NationalityId { get; set; }
    }
}
