using Core.BusinessServices;
using Domain.Questions;
using Domain.Visitors;
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
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<QuestionService>();
builder.Services.AddScoped<ExamEntityMapper>();
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

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<QuestionDatabaseContext>();
    db.Database.Migrate();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors("Local");
app.Run();