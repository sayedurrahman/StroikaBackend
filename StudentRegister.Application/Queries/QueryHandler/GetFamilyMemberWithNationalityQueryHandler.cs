using StudentRegister.Application.Queries.Interfaces;
using StudentRegister.Models.DTOs;
using StudentRegister.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Application.Queries.QueryHandler
{
    public class GetFamilyMemberWithNationalityQueryHandler : IQueryHandler<GetFamilyMemberWithNationalityQuery, CitizenFamilyMemberDTO>
    {
        public CitizenFamilyMemberDTO Handle(GetFamilyMemberWithNationalityQuery t)
        {
            throw new NotImplementedException();
        }
    }
}
