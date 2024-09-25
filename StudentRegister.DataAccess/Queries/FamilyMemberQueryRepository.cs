using StudentRegister.DataAccess.Queries.Interfaces;
using StudentRegister.Models.DTOs;
using StudentRegister.Models.Queries;

namespace StudentRegister.DataAccess.Queries
{
    public class FamilyMemberQueryRepository : IFamilyMemberQueryRepository
    {
        public StudentRegisterContext _context { get; }
        public FamilyMemberQueryRepository(StudentRegisterContext context)
        {
            _context = context;
        }
                
        public FamilyMemberDTO GetFamilyMember(GetFamilyMemberQuery query)
        {
            var fm = _context.FamilyMembers.Find(query.Id);
            if (fm == null)
                throw new KeyNotFoundException();

            return new FamilyMemberDTO(fm);
        }

        public CitizenFamilyMemberDTO GetFamilyMemberWithNationality(GetFamilyMemberWithNationalityQuery query)
        {
            var fm = _context.FamilyMembers.Find(query.Id);
            if (fm == null)
                throw new KeyNotFoundException();

            return new CitizenFamilyMemberDTO(fm);
        }
    }
}
