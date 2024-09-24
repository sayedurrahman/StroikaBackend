namespace StudentRegister.Application.Commands.Interfaces
{
    public interface ICommandHandler<TCommand>
    {
        /// <summary>
        /// Handles a command; Returns related Id (if any) or zero
        /// </summary>
        /// <param name="t">Command</param>
        /// <returns>Id</returns>
        int Handle(TCommand t);
    }
}
