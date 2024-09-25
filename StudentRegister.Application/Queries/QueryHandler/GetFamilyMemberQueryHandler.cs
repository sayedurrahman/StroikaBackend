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
    public class GetFamilyMemberQueryHandler : IQueryHandler<GetFamilyMemberQuery, FamilyMemberDTO>
    {
        public FamilyMemberDTO Handle(GetFamilyMemberQuery t)
        {
            throw new NotImplementedException();
        }
    }
}
