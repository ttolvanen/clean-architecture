using Core.Domain;
using Core.Dtos;
using Core.Interfaces;

namespace Core.Mediators;

public class ExamFormatter : IExamFormatter, IAnswerFormatter
{
    private const string Yes = "yes";
    private const string No = "no";
        
    private readonly List<AnswerDto> _answers = new ();
    public AnswerDto[] Answers => _answers.ToArray();
        
    public ExamFormatter(Exam exam)
    {
        exam.Accept(this);
    }
        
    public void VisitStringAnswer(string question, string answer)
    {
        _answers.Add(new AnswerDto(question, answer));
    }

    public void VisitYesNoAnswer(string questionText, bool answer)
    {
        _answers.Add(new AnswerDto(questionText, answer ? Yes : No));
    }

    public void VisitNumericAnswer(string questionText, int answer)
    {
        _answers.Add(new AnswerDto(questionText, answer.ToString()));
    }

    public void VisitAnsweredQuestions(IEnumerable<IQuestion> answeredQuestions)
    {
        foreach (var question in answeredQuestions)
            question.Accept(this);
    }
}