using StudentRegister.Application.Queries.Interfaces;
using StudentRegister.DataAccess.Queries.Interfaces;
using StudentRegister.Models.DTOs;
using StudentRegister.Models.Queries;

namespace StudentRegister.Application.Queries.QueryHandler
{
    internal class GetStudentQueryHandler : IQueryHandler<GetStudentWithNationalityQuery, StudentDTO>
    {
        private readonly IStudentQueryRepository studentQueryRepository;

        public GetStudentQueryHandler(IStudentQueryRepository studentQueryRepository)
        {
            this.studentQueryRepository = studentQueryRepository;
        }

        public StudentDTO Handle(GetStudentWithNationalityQuery t)
        {
            return studentQueryRepository.GetAStudent(t.StudentId);
        }
    }
}
