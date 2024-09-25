using StudentRegister.Application.Commands.Interfaces;
using StudentRegister.DataAccess.Commands.Interfaces;
using StudentRegister.Models.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Application.Commands.CommandHandler
{
    public class DeleteFamilyMemberCommandHandler : ICommandHandler<DeleteFamilyMemberCommand>
    {
        private readonly IFamilyMemberCommandRepository familyMemberCommandRepository;

        public DeleteFamilyMemberCommandHandler(IFamilyMemberCommandRepository familyMemberCommandRepository)
        {
            this.familyMemberCommandRepository = familyMemberCommandRepository;
        }

        public int Handle(DeleteFamilyMemberCommand t)
        {
            familyMemberCommandRepository.DeleteFamilyMember(t);
            return 0;
        }
    }
}
