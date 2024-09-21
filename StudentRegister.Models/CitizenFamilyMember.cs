using StudentRegister.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Models
{
    public class CitizenFamilyMember: Citizen
    {
        public DateTime DateOfBirth { get; set; }
        public int RelationshipId { get; set; }
    }
}
