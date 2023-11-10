using Core.Interfaces;

namespace Core.Tests.Domain;

internal class NoAnswerVisitor : IAnswerFormatter
{
    public void VisitStringAnswer(string questionText, string answer)
    {
        Assert.Fail("Should not be called");
    }

    public void VisitYesNoAnswer(string questionText, bool answer)
    {
        Assert.Fail("Should not be called");
    }

    public void VisitNumericAnswer(string questionText, int answer)
    {
        Assert.Fail("Should not be called");
    }
}