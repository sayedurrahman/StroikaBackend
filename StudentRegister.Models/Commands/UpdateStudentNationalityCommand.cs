using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Models.Commands
{
    public class UpdateStudentNationalityCommand
    {
        public int StudentId { get; set; }
        public int NationalityId { get; set; }
    }
}
