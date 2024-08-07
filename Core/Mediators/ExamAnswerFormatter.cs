using Core.Dtos;
using Domain;
using Domain.Exams;
using Domain.Questions;
using Domain.Visitors;

namespace Core.Mediators;

public class ExamAnswerFormatter : IExamFormatter, IAnswerFormatter
{
    private const string Yes = "yes";
    private const string No = "no";

    private readonly List<AnswerDto> _answers = [];

    private ExamAnswerFormatter(Exam exam)
    {
        exam.Accept(this);
    }
        
    public void Format(string question, string answer)
    {
        _answers.Add(new AnswerDto(question, answer));
    }

    public void Format(string questionText, bool answer)
    {
        _answers.Add(new AnswerDto(questionText, answer ? Yes : No));
    }

    public void Format(string questionText, int answer)
    {
        _answers.Add(new AnswerDto(questionText, answer.ToString()));
    }

    public void VisitAnsweredQuestions(IEnumerable<IQuestion> answeredQuestions)
    {
        foreach (var question in answeredQuestions)
            question.Accept(this);
    }

    public static AnswerDto[] ExtractAnswers(Exam exam) => 
        new ExamAnswerFormatter(exam)._answers.ToArray();
}