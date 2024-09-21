using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Models
{
    internal class Student : Person
    {
        public DateTime DateOfBirth { get; set; }
    }
}
