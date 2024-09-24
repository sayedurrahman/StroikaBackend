using StudentRegister.Application.Queries.Interfaces;
using StudentRegister.DataAccess.Queries.Interfaces;
using StudentRegister.Models.DTOs;
using StudentRegister.Models.Queries;

namespace StudentRegister.Application.Queries.QueryHandler
{
    public class GetAllStudentQueryHandler : IQueryHandler<GetAllStudentsQuery, StudentDTO[]>
    {
        private readonly IStudentQueryRepository studentQueryRepository;

        public GetAllStudentQueryHandler(IStudentQueryRepository studentQueryRepository)
        {
            this.studentQueryRepository = studentQueryRepository;
        }

        public StudentDTO[] Handle(GetAllStudentsQuery t)
        {
            return studentQueryRepository.GetAllStudents();
        }
    }
}
