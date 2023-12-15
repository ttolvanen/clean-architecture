using Core.Interfaces;
using FluentAssertions;

namespace Core.Tests.Domain;

internal class TestAnswerFormatter(string expectedQuestionText, object expectedAnswer) : IAnswerFormatter
{
    public void VisitStringAnswer(string questionText, string answer)
    {
        questionText.Should().Be(expectedQuestionText);
        answer.Should().Be((string) expectedAnswer);
    }

    public void VisitYesNoAnswer(string questionText, bool answer)
    {
        questionText.Should().Be(expectedQuestionText);
        answer.Should().Be((bool) expectedAnswer);
    }

    public void VisitNumericAnswer(string questionText, int answer)
    {
        questionText.Should().Be(expectedQuestionText);
        answer.Should().Be((int)expectedAnswer);
    }
}