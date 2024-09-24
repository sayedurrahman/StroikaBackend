using StudentRegister.Application.Commands.Interfaces;
using StudentRegister.DataAccess.Commands.Interfaces;
using StudentRegister.Models.Commands;

namespace StudentRegister.Application.Commands.CommandHandler
{
    public class AddFamilyMemberCommandHandler : ICommandHandler<AddFamilyMemberCommand>
    {
        public IStudentCommandRepository StudentCommandRepository { get; }
        public AddFamilyMemberCommandHandler(IStudentCommandRepository studentCommandRepository)
        {
            StudentCommandRepository = studentCommandRepository;
        }

        public int Handle(AddFamilyMemberCommand command)
        {
            return StudentCommandRepository.AddFamilyMemberOfStudent(command);
        }
    }
}
