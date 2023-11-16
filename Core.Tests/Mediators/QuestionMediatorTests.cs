using static Core.Mediators.QuestionAssembler;

namespace Core.Tests.Mediators;

public class QuestionMediatorTests
{
    [Fact]
    public void CreatingDto()
    {
        CreateDto(NameQuestion()).Should().Be(new QuestionDto(WhatIsYourNameText));
        CreateDto(Failure()).Should().Be(new QuestionDto(TheSurveyHasFailedText));
    }
}