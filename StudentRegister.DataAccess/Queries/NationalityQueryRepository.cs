using StudentRegister.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.DataAccess.Queries
{
    public class NationalityQueryRepository : INationalityQueryRepository
    {
        public StudentRegisterContext _studentRegisterContext { get; }

        public NationalityQueryRepository(StudentRegisterContext studentRegisterContext)
        {
            _studentRegisterContext = studentRegisterContext;
        }

        public IEnumerable<NationalityDTO> GetAll()
        {
            return _studentRegisterContext.Nationalities.Select(x => new NationalityDTO() { Id = x.Id, Name = x.NationalityName, AlphaCode = x.Alpha2Code }).ToList();
        }
    }
}
