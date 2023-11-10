using Core.Interfaces;

namespace Core.Tests.Domain;

internal class TestQuestionFormatter(string expectedQuestionText) : IQuestionFormatter
{
    public void VisitPrintText(string question)
    {
        question.Should().Be(expectedQuestionText);
    }
}