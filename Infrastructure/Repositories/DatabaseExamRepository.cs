using System.Runtime.InteropServices.JavaScript;
using Core.BusinessServices;
using Core.Domain;
using Core.Interfaces;
using Core.Mediators;
using Infrastructure.Database;
using Infrastructure.Entities;
using Infrastructure.Mappers;

namespace Infrastructure.Repositories;

public class DatabaseExamRepository(QuestionDatabaseContext dbContext, ExamDataMapper dataMapper, ExamFactory factory) : IExamRepository
{
    public Exam GetExamForStudent(StudentId studentId) => 
        dataMapper.ToDomainModel(GetOrCreate(studentId));

    private ExamEntity GetOrCreate(StudentId studentId)
    {
        var studentIdValue = new IdVisitor().ToId(studentId);

        if (EntityExists(studentIdValue)) 
            return dbContext.Exams.Single(e => e.StudentId == studentIdValue);
        
        var exam = factory.CreateExam(studentId);
        var entity = dataMapper.CreateEntity(studentId, exam);
        dbContext.Exams.Add(entity);
        dbContext.SaveChanges();
        return entity;
    }

    private bool EntityExists(int studentIdValue) => 
        dbContext.Exams.Any(e => e.StudentId == studentIdValue);

    public void UpdateExam(Exam exam)
    {
        var examVisitor = new ExamVisitor(exam);
        var entity = GetOrCreate(examVisitor.StudentId!);
        entity.Update(exam);
        
        dbContext.Update(entity);
        dbContext.SaveChanges(); 
    }
}