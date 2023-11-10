using Core.Interfaces;

namespace Core.Domain;

/// <summary>
/// A question that understands two possible answers: true or false and a flow up question based on the answer.
/// </summary>
internal class BooleanQuestion(string question, IQuestion trueQuestion, IQuestion falseQuestion)
    : IQuestion
{
    private const string True = "true";
    private const string False = "false";
    private const string Yes = "yes";
    private const string No = "no";
    
    private bool? _answer;

    public IQuestion Answer(string value)
    {
        _answer = value switch
        {
            True => true,
            False => false,
            Yes => true,
            No => false,
            _ => throw new ArgumentException($"Answer should be either: {string.Join(", ", True, False, Yes)} or {No} ", nameof(value))
        };
        return GetNextQuestion();
    }

    public void Accept(IQuestionFormatter formatter) => formatter.VisitPrintText(question);
    public void Accept(IAnswerFormatter formatter)
    {
        if(!_answer.HasValue) return;
        formatter.VisitYesNoAnswer(question, _answer.Value);
    }

    private IQuestion GetNextQuestion() => 
        _answer.HasValue ? _answer.Value ?  trueQuestion : falseQuestion : this;
}