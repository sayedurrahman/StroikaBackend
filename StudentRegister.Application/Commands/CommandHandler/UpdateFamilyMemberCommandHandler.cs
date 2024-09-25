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
    public class UpdateFamilyMemberCommandHandler : ICommandHandler<UpdateFamilyMemberCommand>
    {
        private readonly IFamilyMemberCommandRepository familyMemberCommandRepository;

        public UpdateFamilyMemberCommandHandler(IFamilyMemberCommandRepository familyMemberCommandRepository)
        {
            this.familyMemberCommandRepository = familyMemberCommandRepository;
        }

        public int Handle(UpdateFamilyMemberCommand t)
        {
            return familyMemberCommandRepository.UpdateFamilyMember(t);
        }
    }
}
