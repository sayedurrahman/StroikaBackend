using Microsoft.EntityFrameworkCore;
using StudentRegister.Application.Commands.CommandHandler;
using StudentRegister.Application.Queries.QueryHandler;
using StudentRegister.Application.Commands.Interfaces;
using StudentRegister.Application.Queries.Interfaces;
using StudentRegister.DataAccess.Commands;
using StudentRegister.DataAccess.Commands.Interfaces;
using StudentRegister.DataAccess.Queries;
using StudentRegister.DataAccess.Queries.Interfaces;
using StudentRegister.Models.Commands;
using StudentRegister.Models.DTOs;
using StudentRegister.Models.Queries;
using StudentRegister.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StudentRegister.DataAccess.StudentRegisterContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("StudentRegisterConnection")));

RegisterDependencies(builder);
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<StudentRegister.DataAccess.StudentRegisterContext>();

    // Delete and recreate the database on each startup
    dbContext.Database.EnsureDeleted();
    dbContext.Database.EnsureCreated();
    // TODO: Keep or remove
    //CFStoredProcedure.CreateSP(dbContext);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

static void RegisterDependencies(WebApplicationBuilder builder) =>
    builder.Services
           .AddTransient<INationalityQueryRepository, NationalityQueryRepository>()
           .AddTransient<IStudentQueryRepository, StudentQueryRepository>()
           .AddTransient<IStudentCommandRepository, StudentCommandRepository>()
           .AddTransient<IFamilyMemberQueryRepository, FamilyMemberQueryRepository>()
           .AddTransient<IFamilyMemberCommandRepository, FamilyMemberCommandRepository>()
           .AddTransient<ICommandHandler<AddStudentCommand>, AddStudentCommandHandler>()
           .AddTransient<ICommandHandler<UpdateStudentCommand>, UpdateStudentCommandHandler>()
           .AddTransient<ICommandHandler<UpdateStudentNationalityCommand>, UpdateStudentNationalityCommandHandler>()
           .AddTransient<ICommandHandler<AddFamilyMemberCommand>, AddFamilyMemberCommandHandler>()
           .AddTransient<IQueryHandler<GetAllStudentsQuery, StudentDTO[]>, GetAllStudentQueryHandler>()
           .AddTransient<IQueryHandler<GetStudentQuery, StudentDTO>, GetStudentQueryHandler>()
           .AddTransient<IQueryHandler<GetStudentFamilyMembersQuery, FamilyMemberDTO[]>, GetStudentFamilyMembersQueryHandler>()
           .AddTransient<IQueryHandler<GetStudentWithNationalityQuery, CitizenStudentDTO>, GetStudentWithNationalityQueryHandler>()
           .AddTransient<IStudentServices, StudentServices>();