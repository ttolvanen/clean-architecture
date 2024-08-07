using Domain.Visitors;

namespace Domain.Tests.Questions.TestHelpers;

internal class NoAnswerAssertion : IAnswerFormatter
{
    public void Format(string questionText, string answer)
    {
        Assert.Fail("Should not be called");
    }

    public void Format(string questionText, bool answer)
    {
        Assert.Fail("Should not be called");
    }

    public void Format(string questionText, int answer)
    {
        Assert.Fail("Should not be called");
    }
}