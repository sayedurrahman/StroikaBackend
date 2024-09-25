using StudentRegister.Models.Commands;
using StudentRegister.Models.DTOs;
using StudentRegister.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Application
{
    public interface IFamilyMemberService
    {
        FamilyMemberDTO AddStudentFamilyMember(AddFamilyMemberCommand command);
        FamilyMemberDTO UpdateFamilyMember(UpdateFamilyMemberCommand command);
        void DeleteFamilyMember(DeleteFamilyMemberCommand command);
        CitizenFamilyMemberDTO UpdateFamilyMemberNationality(UpdateFamilyMemberNationalityCommand command);
        CitizenFamilyMemberDTO GetFamilyMemberWithNationality(GetFamilyMemberWithNationalityQuery query);
    }
}
