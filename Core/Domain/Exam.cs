using Core.Interfaces;
namespace Core.Domain;

/// <summary>
/// Understands a student's exam and their answered questions.
/// </summary>
public class Exam(StudentId studentId, IQuestion currentQuestion)
{
    private readonly List<IQuestion> _answeredQuestions = new();

    public void Answer(string answer)
    {
        var nextQuestion = currentQuestion.Answer(answer);
        _answeredQuestions.Add(currentQuestion);
        currentQuestion = nextQuestion;
    }
    
    public bool IsReady() => currentQuestion.IsTerminal();

    public IQuestion GetNextQuestion() => currentQuestion;

    public void Accept(IExamFormatter answerFormatter) =>
        answerFormatter.VisitAnsweredQuestions(_answeredQuestions);

    public bool IdMatches(StudentId anotherStudentId) => studentId == anotherStudentId;
}