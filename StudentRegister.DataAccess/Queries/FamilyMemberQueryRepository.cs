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

        /// <summary>
        /// Get family member by id
        /// </summary>
        /// <param name="query"></param>
        /// <returns>Family member</returns>
        /// <exception cref="KeyNotFoundException">If family member cannot be found by the Id</exception>
        public FamilyMemberDTO GetFamilyMember(GetFamilyMemberQuery query)
        {
            var fm = _context.FamilyMembers.Find(query.Id);
            if (fm == null)
                throw new KeyNotFoundException();

            return new FamilyMemberDTO(fm);
        }

        /// <summary>
        /// Get family member with nationality
        /// </summary>
        /// <param name="query"></param>
        /// <returns>Family member with nationality</returns>
        /// <exception cref="KeyNotFoundException">If family member cannot be found by the Id</exception>
        public CitizenFamilyMemberDTO GetFamilyMemberWithNationality(GetFamilyMemberWithNationalityQuery query)
        {
            var fm = _context.FamilyMembers.Find(query.Id);
            if (fm == null)
                throw new KeyNotFoundException();

            return new CitizenFamilyMemberDTO(fm);
        }
    }
}
