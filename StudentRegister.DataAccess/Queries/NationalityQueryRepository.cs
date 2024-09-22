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
        public IEnumerable<NationalityDTO> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
