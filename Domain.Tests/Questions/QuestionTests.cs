using static Domain.Tests.Questions.TestHelpers.QuestionTestExtensions;

namespace Domain.Tests;

public class QuestionTests
{
    [Fact]
    public void PrintQuestion()
    {
        NameQuestion().Accept(ShouldOutput(WhatIsYourNameText));
        AgeQuestion().Accept(ShouldOutput(WhatIsYourAgeText));
        IsEarthRound().Accept(ShouldOutput(IsEarthRoundText));
        Success().Accept(ShouldOutput(ThankYouForTakingTheSurveyText));
        Failure().Accept(ShouldOutput(TheSurveyHasFailedText));
    }

    [Fact]
    public void AcceptWhenNoAnswer()
    {
        NameQuestion().ShouldNotHaveAnswer();
        AgeQuestion().ShouldNotHaveAnswer();
        IsEarthRound().ShouldNotHaveAnswer();
        Success().ShouldNotHaveAnswer();
        Failure().ShouldNotHaveAnswer();
    }
    
    [Fact]
    public void SettingAnswer()
    {
        var nameQuestion = NameQuestion();
        nameQuestion.Answer("Brian").ShouldHaveQuestion(WhatIsYourAgeText);
        nameQuestion.ShouldHaveQuestionAndAnswer(WhatIsYourNameText, "Brian");
        
        var ageQuestion = AgeQuestion();
        ageQuestion.Answer("20").ShouldHaveQuestion(IsEarthRoundText);
        ageQuestion.ShouldHaveQuestionAndAnswer(WhatIsYourAgeText, 20);
        
        var isEarthRoundTrue = IsEarthRound();
        isEarthRoundTrue.Answer("true").ShouldHaveQuestionAndAnswer(ThankYouForTakingTheSurveyText, true);
        isEarthRoundTrue.ShouldHaveQuestionAndAnswer(IsEarthRoundText, true);
        
        var isEarthRoundFalse = IsEarthRound();
        isEarthRoundFalse.Answer("false").ShouldHaveQuestion(TheSurveyHasFailedText);
        isEarthRoundFalse.ShouldHaveQuestionAndAnswer(IsEarthRoundText, false);
        
        IsEarthRound().Answer("yes").ShouldHaveQuestion(ThankYouForTakingTheSurveyText);
        IsEarthRound().Answer("no").ShouldHaveQuestion(TheSurveyHasFailedText);
    }

    [Fact]
    public void TerminalQuestions()
    {
        NameQuestion().IsTerminal().Should().BeFalse();
        AgeQuestion().IsTerminal().Should().BeFalse();
        IsEarthRound().IsTerminal().Should().BeFalse();
        Success().IsTerminal().Should().BeTrue();
        Failure().IsTerminal().Should().BeTrue();
    }
    
    [Fact]
    public void InvalidAnswers(){

        NameQuestion().Invoking(q => q.Answer("10Foo")).Should().NotThrow();
        AgeQuestion().Invoking( q => q.Answer("10")).Should().NotThrow();

        Failure().Invoking(q => q.Answer("any answer")).Should().Throw<InvalidOperationException>();
        Success().Invoking(q => q.Answer("any answer")).Should().Throw<InvalidOperationException>();

        NameQuestion().Invoking(q => q.Answer("10")).Should().NotThrow();
        IsEarthRound().Invoking(q => q.Answer("10")).Should().Throw<ArgumentException>();
        IsEarthRound().Invoking(q => q.Answer("foo")).Should().Throw<ArgumentException>();
        AgeQuestion().Invoking(q => q.Answer("Brian")).Should().Throw<ArgumentException>();
    }
    
    [Fact]
    public void IsTerminal()
    {
        Success().IsTerminal().Should().BeTrue();
        NameQuestion().IsTerminal().Should().BeFalse();
    }
}