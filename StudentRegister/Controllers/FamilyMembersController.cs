using Microsoft.AspNetCore.Mvc;
using StudentRegister.Application;
using StudentRegister.Models.Commands;
using StudentRegister.Models.DTOs;

namespace StudentRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyMembersController : ControllerBase
    {
        private readonly IFamilyMemberService familyMemberService;

        public FamilyMembersController(IFamilyMemberService familyMemberService)
        {
            this.familyMemberService = familyMemberService;
        }

        /// <summary>
        /// PUT api/FamilyMembers/{id}
        /// Update a family member
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="dob"></param>
        /// <param name="relationId"></param>
        /// <returns>Json: Updated family member</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, string firstName, string lastName, DateTime dob, int relationId)
        {
            UpdateFamilyMemberCommand command = new UpdateFamilyMemberCommand()
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dob,
                RelationshipId = relationId
            };
            return Ok(familyMemberService.UpdateFamilyMember(command));
        }

        /// <summary>
        /// DELETE api/FamilyMembers/{id}
        /// Delete a family member by id
        /// </summary>
        /// <param name="id">Json: Family member's id</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            familyMemberService.DeleteFamilyMember(new() { FamilyMemberId = id });
        }

        /// <summary>
        /// GET api/FamilyMembers/{id}/Nationality
        /// Get family member's nationality
        /// </summary>
        /// <param name="id">Family member's id</param>
        /// <returns>Json: Family member with nationality</returns>
        [HttpGet("{id}/Nationality")]
        public IActionResult GetFamilyMemberNationality(int id)
        {
            return Ok(familyMemberService.GetFamilyMemberWithNationality(new() { Id = id }));
        }

        /// <summary>
        /// PUT api/FamilyMembers/{id}/Nationality/{nId}
        /// Update family member's nationality
        /// </summary>
        /// <param name="id">Family member's id</param>
        /// <param name="nID">New nationality id</param>
        /// <returns>Json: Family member with nationality</returns>
        [HttpPut("{id}/Nationality/{nID}")]
        public IActionResult PutFamilyMemberNationality(int id, int nID)
        {
            return Ok(familyMemberService.UpdateFamilyMemberNationality(new() { FamilyMemberId = id, NewNationalityId = nID }));
        }
    }
}
