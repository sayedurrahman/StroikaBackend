using StudentRegister.Models.Entities;

namespace StudentRegister.Models.DTOs
{
    public class NationalityDTO
    {
        public NationalityDTO(Nationality nationality)
        {
            Id = nationality.Id;
            Name = nationality.NationalityName;
            AlphaCode = nationality.Alpha2Code;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string AlphaCode { get; set; }
    }
}
