using StudentRegister.Models.BaseModels;
using StudentRegister.Models.Entities;

namespace StudentRegister.Models.DTOs
{
    public class CitizenStudentDTO : Citizen
    {
        public CitizenStudentDTO(Student student)
        {
            ID = student.ID;
            FirstName = student.FirstName;
            LastName = student.LastName;
            NationalityId = student.NationalityId.HasValue? student.NationalityId.Value : 0;
        }
    }
}
