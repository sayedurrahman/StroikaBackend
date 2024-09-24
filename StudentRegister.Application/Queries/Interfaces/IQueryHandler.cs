namespace StudentRegister.Application.Queries.Interfaces
{
    public interface IQueryHandler<TQuery,TResult>
    {
        /// <summary>
        /// Handles a query
        /// </summary>
        /// <param name="t">Query</param>
        /// <returns>TResult</returns>
        TResult Handle(TQuery t);
    }
}
