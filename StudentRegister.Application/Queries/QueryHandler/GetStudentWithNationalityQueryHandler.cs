using StudentRegister.Application.Queries.Interfaces;
using StudentRegister.DataAccess.Queries.Interfaces;
using StudentRegister.Models.DTOs;
using StudentRegister.Models.Queries;

namespace StudentRegister.Application.Queries.QueryHandler
{
    public class GetStudentWithNationalityQueryHandler : IQueryHandler<GetStudentWithNationalityQuery, CitizenStudentDTO>
    {
        private readonly IStudentQueryRepository studentQueryRepository;

        public GetStudentWithNationalityQueryHandler(IStudentQueryRepository studentQueryRepository)
        {
            this.studentQueryRepository = studentQueryRepository;
        }

        public CitizenStudentDTO Handle(GetStudentWithNationalityQuery t)
        {
            return studentQueryRepository.GetStudentWithNationality(t.StudentId);
        }
    }
}
