namespace Core.Domain;

/// <summary>
/// Simple question is a question that has only one possible typed answer and next question.
/// </summary>
/// <typeparam name="T">Type of answer</typeparam>
internal class SimpleQuestion<T> : IQuestion
{
    private T? _answer;
    private readonly string _questionText;
    private readonly IQuestion _nextQuestion;

    /// <summary>
    /// Simple question is a question that has only one possible typed answer and next question.
    /// </summary>
    /// <typeparam name="T">Type of answer</typeparam>
    public SimpleQuestion(string questionText, IQuestion nextQuestion)
    {
        _questionText = questionText;
        _nextQuestion = nextQuestion;
    }

    public IQuestion Answer(string value)
    {
        try
        {
            _answer = (T) Convert.ChangeType(value, typeof(T));
            return GetNextQuestion();
        }
        catch (FormatException)
        {
            throw new ArgumentException($"Answer should be of type {typeof(T).Name}");
        }
    }
    
    public void Accept(QuestionPrinter printer) => printer.VisitPrintText(_questionText);

    private IQuestion GetNextQuestion() => _answer is not null ? _nextQuestion : this;
}