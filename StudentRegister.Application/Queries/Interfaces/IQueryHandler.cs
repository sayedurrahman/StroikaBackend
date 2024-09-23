using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Application.Queries.Interfaces
{
    public interface IQueryHandler<TQuery,TResult>
    {
        TResult Handle(TQuery t);
    }
}
