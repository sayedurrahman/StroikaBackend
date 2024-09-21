using StudentRegister.Models.BaseModels;

namespace StudentRegister.Models.DTOs
{
    public class StudentDTO : Person
    {
        public DateTime DateOfBirth { get; set; }
    }
}
