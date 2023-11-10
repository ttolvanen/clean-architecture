using Core.Interfaces;

namespace Core.Domain;

/// <summary>
/// Terminal question is the last question in the survey.
/// </summary>
internal class TerminalQuestion(string terminationExplanation) : IQuestion
{
    public IQuestion Answer(string _) => throw new InvalidOperationException("The survey has ended.");
    
    public bool IsTerminal() => true;
    
    public void Accept(IQuestionFormatter formatter) => formatter.VisitPrintText(terminationExplanation);
    public void Accept(IAnswerFormatter _) {}
}