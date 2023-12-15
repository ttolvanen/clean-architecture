using Core.Interfaces;

namespace Core.Domain;

/// <summary>
/// Understands a student's exam and their answered questions.
/// </summary>
public class Exam(StudentId studentId, IQuestion currentQuestion)
{
    private readonly List<IQuestion> _answeredQuestions = [];

    public void Answer(string answer)
    {
        var nextQuestion = currentQuestion.Answer(answer);
        _answeredQuestions.Add(currentQuestion);
        currentQuestion = nextQuestion;
    }
    
    public bool IsReady() => currentQuestion.IsTerminal();

    public IQuestion GetNextQuestion() => currentQuestion;
    
    public bool IdMatches(StudentId anotherStudentId) => studentId == anotherStudentId;
    
    public void Accept(IExamVisitor visitor) => visitor.VisitId(studentId);

    public void Accept(IExamFormatter answerFormatter) =>
        answerFormatter.VisitAnsweredQuestions(_answeredQuestions);

}