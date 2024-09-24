using StudentRegister.Application.Queries.Interfaces;
using StudentRegister.DataAccess.Queries.Interfaces;
using StudentRegister.Models.DTOs;
using StudentRegister.Models.Queries;

namespace StudentRegister.Application.Queries.QueryHandler
{
    public class GetStudentQueryHandler : IQueryHandler<GetStudentQuery, StudentDTO>
    {
        private readonly IStudentQueryRepository studentQueryRepository;

        public GetStudentQueryHandler(IStudentQueryRepository studentQueryRepository)
        {
            this.studentQueryRepository = studentQueryRepository;
        }

        public StudentDTO Handle(GetStudentQuery t)
        {
            return studentQueryRepository.GetAStudent(t.StudentId);
        }
    }
}
