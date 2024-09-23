using StudentRegister.DataAccess.Commands.Interfaces;
using StudentRegister.Models.DTOs;

namespace StudentRegister.DataAccess.Commands
{
    public class FamilyMemberCommandRepository : IFamilyMemberCommandRepository
    {
        public StudentRegisterContext _context { get; }
        public FamilyMemberCommandRepository(StudentRegisterContext context)
        {
            _context = context;
        }

        public void DeleteFamilyMember(int familyMemberId)
        {
            var fm = _context.FamilyMembers.Find(familyMemberId);
            if (fm != null)
                _context.FamilyMembers.Remove(fm);

            _context.SaveChanges();
        }

        public bool UpdateFamilyMember(int familyMemberId, FamilyMemberDTO member)
        {
            var fm = _context.FamilyMembers.Find(familyMemberId);
            if (fm != null)
            {
                fm.FirstName = member.FirstName;
                fm.LastName = member.LastName;
                fm.DateOfBirth = member.DateOfBirth;
                fm.RelationshipId = member.RelationshipId;
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool UpdateNationalityOfAFamilyMember(int familyMemberId, int newNationalityId)
        {
            var fm = _context.FamilyMembers.Find(familyMemberId);
            if (fm != null)
            {
                fm.NationalityId = newNationalityId;
                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
