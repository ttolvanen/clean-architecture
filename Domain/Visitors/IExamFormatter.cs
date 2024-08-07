using Domain.Questions;

namespace Domain.Visitors;

public interface IExamFormatter
{ 
    void VisitAnsweredQuestions(IEnumerable<IQuestion> answeredQuestions);
}