using Core.Mediators;
using Domain.Exams;

namespace Infrastructure.Entities;

public class ExamEntity   
{
    public int Id { get; init; }
    public int StudentId { get; init; }
    public List<AnsweredQuestion> AnsweredQuestions { get; set; } = [];
    
    public void Update(Exam exam) =>
        AnsweredQuestions = 
            ExamAnswerFormatter.ExtractAnswers(exam)
                .Select( a => new AnsweredQuestion(a.Question, a.Answer)).ToList();
}