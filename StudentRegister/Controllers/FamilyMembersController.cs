using Microsoft.AspNetCore.Mvc;
using StudentRegister.Models.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyMembersController : ControllerBase
    {
        // GET api/FamilyMembers/5
        //[HttpGet("{id}")]
        private FamilyMemberDTO Get(int id)
        {
            //return new() { ID = 1, FirstName = "John", LastName = "Doe", RelationshipId = 1, DateOfBirth = DateTime.Now };
            return null;
        }

        // PUT api/FamilyMembers/5
        [HttpPut("{id}")]
        //TODO: check input
        public FamilyMemberDTO Put(int id, [FromBody] string value)
        {
            return Get(id);
        }

        // DELETE api/FamilyMembers/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // GET api/FamilyMembers/5/Nationality
        [HttpGet("{id}/Nationality")]
        public CitizenFamilyMemberDTO GetFamilyMemberNationality(int id)
        {
            //return new() { ID = 1, FirstName = "John", LastName = "Doe", RelationshipId = 1, DateOfBirth = DateTime.Now, NationalityId = 1 };
            return null;
        }

        // PUT api/FamilyMembers/5/Nationality/{nId}
        [HttpPut("{id}/Nationality/{nID}")]
        //TODO: check input
        public CitizenFamilyMemberDTO PutFamilyMemberNationality(int id, int nID)
        {
            return GetFamilyMemberNationality(id);
        }
    }
}
