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
    public class UpdateStudentCommandHandler : ICommandHandler<UpdateStudentCommand>
    {
        private readonly IStudentCommandRepository studentCommandRepository;

        public UpdateStudentCommandHandler(IStudentCommandRepository studentCommandRepository)
        {
            this.studentCommandRepository = studentCommandRepository;
        }

        public int Handle(UpdateStudentCommand command)
        {
            return studentCommandRepository.UpdateStudent(command);
        }
    }
}
