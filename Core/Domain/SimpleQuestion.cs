using Core.Dtos;
using Core.Interfaces;

namespace Core.Domain;

/// <summary>
/// Simple question is a question that has only one possible typed answer and next question.
/// </summary>
/// <typeparam name="T">Type of answer</typeparam>
internal abstract class SimpleQuestion<T>(string questionText, IQuestion nextQuestion) : IQuestion
{
    protected T? GivenAnswer;
    protected readonly string QuestionText = questionText;

    public IQuestion Answer(string value)
    {
        try
        {
            GivenAnswer = (T) Convert.ChangeType(value, typeof(T));
            return GetNextQuestion();
        }
        catch (FormatException)
        {
            throw new ArgumentException($"Answer should be of type {typeof(T).Name}");
        }
    }
    
    public void Accept(IQuestionFormatter formatter) => formatter.VisitPrintText(QuestionText);

    public abstract void Accept(IAnswerFormatter formatter);
    
    private IQuestion GetNextQuestion() => GivenAnswer is not null ? nextQuestion : this;
}