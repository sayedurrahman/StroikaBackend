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
           //.AddScoped<StudentDTO, StudentDTO>()
           //.AddScoped<FamilyMemberDTO, FamilyMemberDTO>()
           //.AddScoped<CitizenStudentDTO, CitizenStudentDTO>()
           .AddScoped<INationalityQueryRepository, NationalityQueryRepository>()
           .AddScoped<IStudentQueryRepository, StudentQueryRepository>()
           .AddScoped<IStudentCommandRepository, StudentCommandRepository>()
           .AddScoped<IFamilyMemberQueryRepository, FamilyMemberQueryRepository>()
           .AddScoped<IFamilyMemberCommandRepository, FamilyMemberCommandRepository>()
           .AddScoped<ICommandHandler<AddStudentCommand>, AddStudentCommandHandler>()
           .AddScoped<ICommandHandler<UpdateStudentCommand>, UpdateStudentCommandHandler>()
           .AddScoped<ICommandHandler<UpdateStudentNationalityCommand>, UpdateStudentNationalityCommandHandler>()
           .AddScoped<ICommandHandler<AddFamilyMemberCommand>, AddFamilyMemberCommandHandler>()
           .AddScoped<IQueryHandler<GetAllStudentsQuery, StudentDTO[]>, GetAllStudentQueryHandler>()
           .AddScoped<IQueryHandler<GetStudentQuery, StudentDTO>, GetStudentQueryHandler>()
           .AddScoped<IQueryHandler<GetStudentFamilyMembersQuery, FamilyMemberDTO[]>, GetStudentFamilyMembersQueryHandler>()
           .AddScoped<IQueryHandler<GetStudentWithNationalityQuery, CitizenStudentDTO>, GetStudentWithNationalityQueryHandler>(); 