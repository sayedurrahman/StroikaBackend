using StudentRegister.Application.Commands.Interfaces;
using StudentRegister.DataAccess.Commands.Interfaces;
using StudentRegister.Models.Commands;

namespace StudentRegister.Application.Commands.CommandHandler
{
    public class UpdateStudentNationalityCommandHandler : ICommandHandler<UpdateStudentNationalityCommand>
    {
        private readonly IStudentCommandRepository studentCommandRepository;

        public UpdateStudentNationalityCommandHandler(IStudentCommandRepository studentCommandRepository)
        {
            this.studentCommandRepository = studentCommandRepository;
        }

        public int Handle(UpdateStudentNationalityCommand command)
        {
            return studentCommandRepository.UpdateNationalityOfStudent(command);
        }
    }
}
