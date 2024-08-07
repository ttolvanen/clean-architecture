using Core.BusinessServices;
using Core.Mediators;
using Domain.Exams;
using Domain.Visitors;
using Infrastructure.Database;
using Infrastructure.Entities;
using Infrastructure.Mappers;

namespace Infrastructure.Repositories;

public class DatabaseExamRepository(QuestionDatabaseContext dbContext, ExamEntityMapper entityMapper, ExamFactory factory) : IExamRepository
{
    public Exam GetExamForStudent(StudentId studentId) => 
        entityMapper.ToDomainModel(GetOrCreate(studentId));

    private ExamEntity GetOrCreate(StudentId studentId)
    {
        var studentIdValue = new IdVisitor().ToNumber(studentId);

        if (EntityExists(studentIdValue)) 
            return dbContext.Exams.Single(e => e.StudentId == studentIdValue);
        
        var exam = factory.CreateExam(studentId);
        var entity = ExamEntityMapper.CreateEntity(studentId, exam);
        dbContext.Exams.Add(entity);
        dbContext.SaveChanges();
        return entity;
    }

    private bool EntityExists(int studentIdValue) => 
        dbContext.Exams.Any(e => e.StudentId == studentIdValue);

    public void UpdateExam(Exam exam)
    {
        var entity = GetOrCreate(new ExamStudentIdAccessor(exam).StudentId);
        entity.Update(exam);
        
        dbContext.Update(entity);
        dbContext.SaveChanges(); 
    }
}