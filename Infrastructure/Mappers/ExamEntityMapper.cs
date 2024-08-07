using Core.BusinessServices;
using Core.Mediators;
using Domain;
using Domain.Exams;
using Infrastructure.Entities;

namespace Infrastructure.Mappers;

public class ExamEntityMapper(ExamFactory factory )
{
    public Exam ToDomainModel(ExamEntity examEntity)
    {
        var exam = factory.CreateExam(examEntity.StudentId.StudentId());
        foreach (var answeredQuestion in examEntity.AnsweredQuestions) 
            exam.Answer(answeredQuestion.Answer);
        return exam;
    }

    public static ExamEntity CreateEntity(StudentId studentId, Exam exam)
    {
        var examEntity = new ExamEntity { StudentId = new IdVisitor().ToNumber(studentId) };
        examEntity.Update(exam);
        return examEntity;
    }
}