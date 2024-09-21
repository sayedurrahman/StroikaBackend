using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Models.BaseModels
{
    public abstract class Citizen : Person
    {
        public int NationalityId { get; set; }
    }
}
