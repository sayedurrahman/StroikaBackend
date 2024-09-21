namespace StudentRegister.Models.BaseModels
{
    public abstract class Citizen : Person
    {
        public int NationalityId { get; set; }
    }
}
