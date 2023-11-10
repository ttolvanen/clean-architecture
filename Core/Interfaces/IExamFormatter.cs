using Core.Domain;

namespace Core.Interfaces;

public interface IExamFormatter
{ 
    void VisitAnsweredQuestions(IEnumerable<IQuestion> answeredQuestions);
}