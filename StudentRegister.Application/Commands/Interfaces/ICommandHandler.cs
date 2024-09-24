using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Application.Commands.Interfaces
{
    public interface ICommandHandler<TCommand>
    {
        /// <summary>
        /// Handles a command
        /// Returns Id or zero
        /// </summary>
        /// <param name="t">Command</param>
        /// <returns>Id</returns>
        int Handle(TCommand t);
    }
}
