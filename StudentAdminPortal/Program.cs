using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.Data;
using StudentAdminPortal.Repository;
using StudentAdminPortal.StudentMapper;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;
// Add services to the container.



builder.Services.AddCors();
builder.Services.AddDbContext<StudentAdminDbContext>(Options => Options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddAutoMapper(typeof(StudentMapping));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
