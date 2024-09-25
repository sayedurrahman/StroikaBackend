using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Models.Commands
{
    public class UpdateFamilyMemberNationalityCommand
    {
        public int FamilyMemberId { get; set; }
        public int NewNationalityId { get; set; }
    }
}
