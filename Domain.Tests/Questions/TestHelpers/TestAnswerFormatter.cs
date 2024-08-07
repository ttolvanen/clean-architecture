using Domain.Visitors;

namespace Domain.Tests;

internal class TestAnswerFormatter(string expectedQuestionText, object expectedAnswer) : IAnswerFormatter
{
    public void Format(string questionText, string answer)
    {
        questionText.Should().Be(expectedQuestionText);
        answer.Should().Be((string) expectedAnswer);
    }

    public void Format(string questionText, bool answer)
    {
        questionText.Should().Be(expectedQuestionText);
        answer.Should().Be((bool) expectedAnswer);
    }

    public void Format(string questionText, int answer)
    {
        questionText.Should().Be(expectedQuestionText);
        answer.Should().Be((int)expectedAnswer);
    }
}