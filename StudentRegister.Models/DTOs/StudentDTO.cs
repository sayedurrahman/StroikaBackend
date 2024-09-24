using StudentRegister.Models.BaseModels;
using StudentRegister.Models.Entities;

namespace StudentRegister.Models.DTOs
{
    public class StudentDTO : Person
    {
        public StudentDTO()
        {
            
        }
        public StudentDTO(Student student)
        {
            ID = student.ID;
            FirstName = student.FirstName;
            LastName = student.LastName;
            DateOfBirth = student.DateOfBirth;
        }

        public DateTime DateOfBirth { get; set; }
    }
}
