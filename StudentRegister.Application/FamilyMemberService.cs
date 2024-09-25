using StudentRegister.Application.Commands.Interfaces;
using StudentRegister.Application.Queries.Interfaces;
using StudentRegister.Models.Commands;
using StudentRegister.Models.DTOs;
using StudentRegister.Models.Queries;

namespace StudentRegister.Application
{
    public class FamilyMemberService : IFamilyMemberService
    {
        private readonly ICommandHandler<AddFamilyMemberCommand> addFamilyMemberCommandHandler;
        private readonly ICommandHandler<UpdateFamilyMemberCommand> updateFamilyMemberCommandHandler;
        private readonly ICommandHandler<UpdateFamilyMemberNationalityCommand> updateFamilyMemberNationalityCommandHandler;
        private readonly ICommandHandler<DeleteFamilyMemberCommand> deleteFamilyMemberCommandHandler;
        private readonly IQueryHandler<GetFamilyMemberWithNationalityQuery, CitizenFamilyMemberDTO> getFamilyMemberWithNationalityQueryHandler;
        private readonly IQueryHandler<GetFamilyMemberQuery, FamilyMemberDTO> getFamilyMemberQueryHandler;

        public FamilyMemberService(ICommandHandler<AddFamilyMemberCommand> addFamilyMemberCommandHandler,
                                   ICommandHandler<UpdateFamilyMemberCommand> updateFamilyMemberCommandHandler,
                                   ICommandHandler<UpdateFamilyMemberNationalityCommand> updateFamilyMemberNationalityCommandHandler,
                                   ICommandHandler<DeleteFamilyMemberCommand> deleteFamilyMemberCommandHandler,
                                   IQueryHandler<GetFamilyMemberWithNationalityQuery, CitizenFamilyMemberDTO> getFamilyMemberWithNationalityQueryHandler,
                                   IQueryHandler<GetFamilyMemberQuery, FamilyMemberDTO> getFamilyMemberQueryHandler)
        {
            this.addFamilyMemberCommandHandler = addFamilyMemberCommandHandler;
            this.updateFamilyMemberCommandHandler = updateFamilyMemberCommandHandler;
            this.updateFamilyMemberNationalityCommandHandler = updateFamilyMemberNationalityCommandHandler;
            this.deleteFamilyMemberCommandHandler = deleteFamilyMemberCommandHandler;
            this.getFamilyMemberWithNationalityQueryHandler = getFamilyMemberWithNationalityQueryHandler;
            this.getFamilyMemberQueryHandler = getFamilyMemberQueryHandler;
        }

        public FamilyMemberDTO AddStudentFamilyMember(AddFamilyMemberCommand command)
        {
            int fmId = addFamilyMemberCommandHandler.Handle(command);
            return GetFamilyMemberById(new() { Id = fmId });
        }

        public FamilyMemberDTO UpdateFamilyMember(UpdateFamilyMemberCommand command)
        {
            int fmId = updateFamilyMemberCommandHandler.Handle(command);
            return GetFamilyMemberById(new() { Id = fmId });
        }

        public CitizenFamilyMemberDTO UpdateFamilyMemberNationality(UpdateFamilyMemberNationalityCommand command)
        {
            int fmId = updateFamilyMemberNationalityCommandHandler.Handle(command);
            return getFamilyMemberWithNationalityQueryHandler.Handle(new() { Id = fmId });
        }

        public void DeleteFamilyMember(DeleteFamilyMemberCommand command)
        {
            deleteFamilyMemberCommandHandler.Handle(command);
        }

        public CitizenFamilyMemberDTO GetFamilyMemberWithNationality(GetFamilyMemberWithNationalityQuery query)
        {
            return getFamilyMemberWithNationalityQueryHandler.Handle(query);
        }

        private FamilyMemberDTO GetFamilyMemberById(GetFamilyMemberQuery getFamilyMemberQuery)
        {
            return getFamilyMemberQueryHandler.Handle(getFamilyMemberQuery);
        }
    }
}
