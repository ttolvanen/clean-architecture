namespace Core.Domain;

/// <summary>
/// A question that understands two possible answers: true or false and a flow up question based on the answer.
/// </summary>
internal class BooleanQuestion : IQuestion
{
    private bool? _answer;
    private readonly string _question;
    private readonly IQuestion _trueQuestion;
    private readonly IQuestion _falseQuestion;

    public BooleanQuestion(string question, IQuestion trueQuestion, IQuestion falseQuestion)
    {
        _question = question;
        _trueQuestion = trueQuestion;
        _falseQuestion = falseQuestion;
    }

    public IQuestion Answer(string value)
    {
        _answer = value switch
        {
            "true" => true,
            "false" => false,
            "yes" => true,
            "no" => false,
            _ => throw new ArgumentException("Answer should be either 'true', 'false', 'yes' or 'no ", nameof(value))
        };
        return GetNextQuestion();
    }

    public void Accept(QuestionPrinter printer) => printer.VisitPrintText(_question);

    private IQuestion GetNextQuestion() => 
        _answer.HasValue ? _answer.Value ?  _trueQuestion : _falseQuestion : this;
}