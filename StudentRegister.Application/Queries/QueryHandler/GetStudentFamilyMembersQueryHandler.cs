using StudentRegister.Application.Queries.Interfaces;
using StudentRegister.DataAccess.Queries.Interfaces;
using StudentRegister.Models.DTOs;
using StudentRegister.Models.Queries;

namespace StudentRegister.Application.Queries.QueryHandler
{
    public class GetStudentFamilyMembersQueryHandler : IQueryHandler<GetStudentFamilyMembersQuery, FamilyMemberDTO[]>
    {
        private readonly IStudentQueryRepository studentQueryRepository;

        public GetStudentFamilyMembersQueryHandler(IStudentQueryRepository studentQueryRepository)
        {
            this.studentQueryRepository = studentQueryRepository;
        }

        public FamilyMemberDTO[] Handle(GetStudentFamilyMembersQuery t)
        {
            return studentQueryRepository.GetFamilyMembersOfAStudent(t.StudentId);
        }
    }
}
