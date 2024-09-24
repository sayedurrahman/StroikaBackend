using StudentRegister.Application.Commands.Interfaces;
using StudentRegister.Models.Commands;
using StudentRegister.DataAccess.Commands.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Application.Commands.CommandHandler
{
    public class AddStudentCommandHandler : ICommandHandler<AddStudentCommand>
    {
        public IStudentCommandRepository StudentCommandRepository { get; }
        public AddStudentCommandHandler(IStudentCommandRepository studentCommandRepository)
        {
            StudentCommandRepository = studentCommandRepository;
        }

        public int Handle(AddStudentCommand command)
        {
            return StudentCommandRepository.AddStudent(command);
        }
    }
}
