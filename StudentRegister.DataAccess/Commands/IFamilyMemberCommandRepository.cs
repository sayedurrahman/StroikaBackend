using StudentRegister.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.DataAccess.Commands
{
    public interface IFamilyMemberCommandRepository
    {
        bool UpdateFamilyMember(int familyMemberId, FamilyMemberDTO member);
        void DeleteFamilyMember(int familyMemberId);
        bool UpdateNationalityOfAFamilyMember(int familyMemberId, int newNationalityId);
    }
}
