using Core.BusinessServices;
using Core.Domain;
using Core.Mediators;
using Infrastructure.Entities;

namespace Infrastructure.Mappers;

public class ExamDataMapper(ExamFactory factory )
{
    public Exam ToDomainModel(ExamEntity examEntity)
    {
        var exam = factory.CreateExam(examEntity.StudentId.StudentId());
        foreach (var answeredQuestion in examEntity.AnsweredQuestions) 
            exam.Answer(answeredQuestion.Answer);
        return exam;
    }

    public ExamEntity CreateEntity(StudentId studentId, Exam exam)
    {
        var examEntity = new ExamEntity { StudentId = new IdVisitor().ToId(studentId) };
        examEntity.Update(exam);
        return examEntity;
    }
}
