using Microsoft.AspNetCore.Mvc;
using StudentRegister.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyMembersController : ControllerBase
    {
        // GET api/FamilyMembers/5
        //[HttpGet("{id}")]
        private FamilyMember Get(int id)
        {
            return new() { ID = 1, FirstName = "John", LastName = "Doe", RelationshipId = 1, DateOfBirth = DateTime.Now };
        }

        // PUT api/FamilyMembers/5
        [HttpPut("{id}")]
        //TODO: check input
        public FamilyMember Put(int id, [FromBody] string value)
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
        public CitizenFamilyMember GetFamilyMemberNationality(int id)
        {
            return new() { ID = 1, FirstName = "John", LastName = "Doe", RelationshipId = 1, DateOfBirth = DateTime.Now, NationalityId = 1 };
        }

        // PUT api/FamilyMembers/5/Nationality/{nId}
        [HttpPut("{id}/Nationality/{nID}")]
        //TODO: check input
        public CitizenFamilyMember PutFamilyMemberNationality(int id, int nID)
        {
            return GetFamilyMemberNationality(id);
        }
    }
}
