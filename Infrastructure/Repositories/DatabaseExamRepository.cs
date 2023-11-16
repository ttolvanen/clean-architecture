using Core.Domain;
using Core.Interfaces;
using Core.Mediators;
using Infrastructure.Database;

namespace Infrastructure.Repositories;

public class DatabaseExamRepository(QuestionDatabaseContext dbContext) : IExamRepository
{
    public Exam GetExamForStudent(StudentId studentId)
    {
        var studentIdValue = new IdVisitor().ToId(studentId);
       // Get the exam entity from database
       var examEntity = dbContext.Exams.FirstOrDefault( e => e.StudentId == studentIdValue);
       // Map the entity to the domain model exam and initialize questions
       throw new NotImplementedException();
    }

    public void UpdateExam(Exam exam)
    {
        // Map the domain model exam to the entity (DataMapper)
        
        // create or update the entity in the database
        throw new NotImplementedException();
        
    }
}