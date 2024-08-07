using Domain.Visitors;

namespace Domain.Tests;

internal class TestQuestionFormatter(string expectedQuestionText) : IQuestionFormatter
{
    public void Format(string question)
    {
        question.Should().Be(expectedQuestionText);
    }
}