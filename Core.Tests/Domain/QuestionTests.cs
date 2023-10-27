using static Core.Domain.IQuestion;
using static Core.Tests.Domain.QuestionTestExtensions;

namespace Core.Tests.Domain;

public class QuestionTests
{
    private const string WhatIsYourName = "What is your name?";
    private const string WhatIsYourAge = "What is your age?";
    private const string IsEarthRound = "Is earth round?";
    private const string ThankYouForTakingTheSurvey = "Thank you for taking the survey!";
    private const string TheSurveyHasFailed = "The survey has failed.";
    
    [Fact]
    public void PrintQuestion()
    {
        NameQuestion().Accept(ShouldOutput(WhatIsYourName));
        NameQuestion().Accept(ShouldOutput(WhatIsYourName));
        AgeQuestion().Accept(ShouldOutput(WhatIsYourAge));
        IsEarthRound().Accept(ShouldOutput(IsEarthRound));
        Success().Accept(ShouldOutput(ThankYouForTakingTheSurvey));
        Failure().Accept(ShouldOutput(TheSurveyHasFailed));
    }
    
    [Fact]
    public void SettingAnswer()
    {
        NameQuestion().Answer("Brian").ShouldHaveQuestionText(WhatIsYourAge);
        AgeQuestion().Answer("20").ShouldHaveQuestionText(IsEarthRound);
        IsEarthRound().Answer("true").ShouldHaveQuestionText(ThankYouForTakingTheSurvey);
        IsEarthRound().Answer("yes").ShouldHaveQuestionText(ThankYouForTakingTheSurvey);
        IsEarthRound().Answer("false").ShouldHaveQuestionText(TheSurveyHasFailed);
        IsEarthRound().Answer("no").ShouldHaveQuestionText(TheSurveyHasFailed);

        NameQuestion().Invoking(q => q.Answer("10Foo")).Should().NotThrow();
        AgeQuestion().Invoking( q => q.Answer("10")).Should().NotThrow();

        Failure().Invoking(q => q.Answer("any answer")).Should().Throw<InvalidOperationException>();
        Success().Invoking(q => q.Answer("any answer")).Should().Throw<InvalidOperationException>();
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

internal static  class QuestionTestExtensions
{

    public static void ShouldHaveQuestionText(this IQuestion question, string expectedText) =>
        question.Accept(new FakeFormatter(expectedText));
    
    public static QuestionPrinter ShouldOutput(string expectedText) => 
        new FakeFormatter(expectedText);
}

internal class FakeFormatter : QuestionPrinter
{
    private readonly string _expectedQuestionText;

    public FakeFormatter(string expectedQuestionText)
    {
        _expectedQuestionText = expectedQuestionText;
    }

    public void VisitPrintText(string question)
    {
        question.Should().Be(_expectedQuestionText);
    }
}