using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

public class QuestionDatabaseContext(DbContextOptions<QuestionDatabaseContext> options) : DbContext(options)
{
    internal DbSet<ExamEntity> Exams => Set<ExamEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ExamEntity>()
            .OwnsMany<AnsweredQuestion>(e => e.AnsweredQuestions, ownedNavigationBuilder =>
            {
                ownedNavigationBuilder.ToJson();
            });

    }
};