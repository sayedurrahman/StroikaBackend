using StudentRegister.Models.BaseModels;

namespace StudentRegister.Models
{
    public class Student : Person
    {
        public DateTime DateOfBirth { get; set; }
    }
}
