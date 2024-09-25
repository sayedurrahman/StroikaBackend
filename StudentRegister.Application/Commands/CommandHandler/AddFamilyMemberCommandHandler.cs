using StudentRegister.Application.Commands.Interfaces;
using StudentRegister.DataAccess.Commands.Interfaces;
using StudentRegister.Models.Commands;

namespace StudentRegister.Application.Commands.CommandHandler
{
    public class AddFamilyMemberCommandHandler : ICommandHandler<AddFamilyMemberCommand>
    {
        public IFamilyMemberCommandRepository familyMemberCommandRepository { get; }
        public AddFamilyMemberCommandHandler(IFamilyMemberCommandRepository familyMemberCommandRepository)
        {
            this.familyMemberCommandRepository = familyMemberCommandRepository;
        }

        public int Handle(AddFamilyMemberCommand command)
        {
            return familyMemberCommandRepository.AddFamilyMemberOfStudent(command);
        }
    }
}
