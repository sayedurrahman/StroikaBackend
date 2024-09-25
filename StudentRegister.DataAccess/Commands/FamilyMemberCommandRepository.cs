using StudentRegister.DataAccess.Commands.Interfaces;
using StudentRegister.Models.Commands;
using StudentRegister.Models.Entities;

namespace StudentRegister.DataAccess.Commands
{
    public class FamilyMemberCommandRepository : IFamilyMemberCommandRepository
    {
        public StudentRegisterContext _context { get; }
        public FamilyMemberCommandRepository(StudentRegisterContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add a new family member of a Student
        /// </summary>
        /// <param name="familyMember"></param>
        /// <returns>Family member's Id</returns>
        public int AddFamilyMemberOfStudent(AddFamilyMemberCommand familyMember)
        {
            var fM = new FamilyMember
            {
                StudentID = familyMember.StudentId,
                FirstName = familyMember.FirstName,
                LastName = familyMember.LastName,
                RelationshipId = familyMember.RelationshipId,
                DateOfBirth = familyMember.DateOfBirth,
                AddedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
            };
            _context.FamilyMembers.Add(fM);
            _context.SaveChanges();
            return fM.ID;
        }


        public void DeleteFamilyMember(DeleteFamilyMemberCommand command)
        {
            var fm = _context.FamilyMembers.Find(command.FamilyMemberId);
            if (fm != null)
                _context.FamilyMembers.Remove(fm);

            _context.SaveChanges();
        }

        public int UpdateFamilyMember(UpdateFamilyMemberCommand command)
        {
            var fm = _context.FamilyMembers.Find(command.Id);
            if (fm != null)
            {
                fm.FirstName = command.FirstName;
                fm.LastName = command.LastName;
                fm.DateOfBirth = command.DateOfBirth;
                fm.RelationshipId = command.RelationshipId;
                _context.SaveChanges();
                return fm.ID;
            }

            return 0;
        }

        public int UpdateNationalityOfAFamilyMember(UpdateFamilyMemberNationalityCommand command)
        {
            var fm = _context.FamilyMembers.Find(command.FamilyMemberId);
            if (fm != null)
            {
                fm.NationalityId = command.NewNationalityId;
                _context.SaveChanges();
                return command.FamilyMemberId;
            }

            return 0;
        }
    }
}
