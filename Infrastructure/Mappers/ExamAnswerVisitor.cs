using Core.Domain;
using Core.Interfaces;
using Infrastructure.Entities;

namespace Infrastructure.Mappers;

public class ExamAnswerVisitor : IExamFormatter, IAnswerFormatter
{
    private readonly List<AnsweredQuestion> _answeredQuestions = [];
 
    public void VisitAnsweredQuestions(IEnumerable<IQuestion> answeredQuestions)
    {
        foreach (var question in answeredQuestions)   
            question.Accept(this);
    }

    public void VisitStringAnswer(string questionText, string answer)
    {
        CreateAnsweredQuestion(questionText, answer);
    }

    private void CreateAnsweredQuestion(string questionText, string answer)
    {
        _answeredQuestions.Add(new AnsweredQuestion(){ QuestionText = questionText, Answer = answer });
    }

    public void VisitYesNoAnswer(string questionText, bool answer)
    {
        CreateAnsweredQuestion(questionText, answer ? "yes" : "no");
    }

    public void VisitNumericAnswer(string questionText, int answer)
    {
       CreateAnsweredQuestion(questionText, answer.ToString());
    }
}