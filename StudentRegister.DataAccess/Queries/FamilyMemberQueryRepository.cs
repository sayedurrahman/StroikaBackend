using StudentRegister.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.DataAccess.Queries
{
    public class FamilyMemberQueryRepository : IFamilyMemberQueryRepository
    {
        public StudentRegisterContext _context { get; }
        public FamilyMemberQueryRepository(StudentRegisterContext context)
        {
            _context = context;
        }
                
        public FamilyMemberDTO GetFamilyMember(int id)
        {
            var fm = _context.FamilyMembers.Find(id);
            if (fm == null)
                throw new KeyNotFoundException();

            return new FamilyMemberDTO(fm);
        }

        public CitizenFamilyMemberDTO GetFamilyMemberWithNationality(int id)
        {
            var fm = _context.FamilyMembers.Find(id);
            if (fm == null)
                throw new KeyNotFoundException();

            return new CitizenFamilyMemberDTO(fm);
        }
    }
}
