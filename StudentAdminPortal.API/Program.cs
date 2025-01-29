using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.API.Data;
using StudentAdminPortal.API.Profiles;
using StudentAdminPortal.API.Repositories.Interfaces;
using StudentAdminPortal.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//inject the DB

builder.Services.AddDbContext<StudentAdminContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StudentAdminDB")));


// Register repository services
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

// Inject AutoMapper service
builder.Services.AddAutoMapper(typeof(AutomapperProfiles));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
