using StudentRegister.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.DataAccess.Queries
{
    public interface IFamilyMemberQueryRepository
    {
        FamilyMemberDTO GetFamilyMember(int id);
        CitizenFamilyMemberDTO GetFamilyMemberWithNationality(int id);
    }
}
