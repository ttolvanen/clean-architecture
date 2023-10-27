namespace Core.Domain;

/// <summary>
/// Terminal question is the last question in the survey.
/// </summary>
internal class TerminalQuestion : IQuestion
{
    private readonly string _terminationExplanation;

    public TerminalQuestion(string terminationExplanation)
    {
        _terminationExplanation = terminationExplanation;
    }

    public IQuestion Answer(string _) => throw new InvalidOperationException("The survey has ended.");
    
    public bool IsTerminal() => true;
    
    public void Accept(QuestionPrinter printer) => printer.VisitPrintText(_terminationExplanation);
}