using Microsoft.AspNetCore.Mvc;
using StudentRegister.Application;
using StudentRegister.Models.Commands;
using StudentRegister.Models.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        // PUT api/FamilyMembers/5
        [HttpPut("{id}")]
        //TODO: check input
        public FamilyMemberDTO Put(int id, string firstName, string lastName, DateTime dob, int relationId)
        {
            UpdateFamilyMemberCommand command = new UpdateFamilyMemberCommand()
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dob,
                RelationshipId = relationId
            };
            return familyMemberService.UpdateFamilyMember(command);
        }

        // DELETE api/FamilyMembers/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            familyMemberService.DeleteFamilyMember(new() { FamilyMemberId = id });
        }

        // GET api/FamilyMembers/5/Nationality
        [HttpGet("{id}/Nationality")]
        public CitizenFamilyMemberDTO GetFamilyMemberNationality(int id)
        {
            return familyMemberService.GetFamilyMemberWithNationality(new() { Id = id });
        }

        // PUT api/FamilyMembers/5/Nationality/{nId}
        [HttpPut("{id}/Nationality/{nID}")]
        //TODO: check input
        public CitizenFamilyMemberDTO PutFamilyMemberNationality(int id, int nID)
        {
            return familyMemberService.UpdateFamilyMemberNationality(new() { FamilyMemberId = id, NewNationalityId = nID });
        }
    }
}
