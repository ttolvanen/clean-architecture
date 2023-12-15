using Core.BusinessServices;
using Core.Domain;
using Core.Interfaces;
using Infrastructure.Database;
using Infrastructure.Mappers;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "Local",
        policy  =>
        {
            policy.WithOrigins("http://localhost:4200");
        });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<QuestionService>();
builder.Services.AddScoped<ExamDataMapper>();
builder.Services.AddSingleton(new ExamFactory(IQuestion.NameQuestion()));
builder.Services.AddDbContext<QuestionDatabaseContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddScoped<IExamRepository,DatabaseExamRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();