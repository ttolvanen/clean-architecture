using Domain.Visitors;
using static Domain.Questions.QuestionConstants;

namespace Domain.Questions;

internal static class QuestionConstants
{
    public const string WhatIsYourNameText = "What is your name?";
    public const string WhatIsYourAgeText = "What is your age?";
    public const string IsEarthRoundText = "Is earth round?";
    public const string ThankYouForTakingTheSurveyText = "Thank you for taking the survey!";
    public const string TheSurveyHasFailedText = "The survey has failed.";
}

/// <summary>
/// Questions structure
/// </summary>
/// <example>
/// "What is your name?" ->
///     "What is your age?" ->
///         "Is earth round?" ->
///                 true -> "Thank you for taking the survey!" (success)
///                 false -> "The survey has failed." (failure)
/// </example>
public interface IQuestion
{
    public static IQuestion Failure() => TheSurveyHasFailedText.TerminalQuestion();   
    public static IQuestion Success() => ThankYouForTakingTheSurveyText.TerminalQuestion();
    public static IQuestion IsEarthRound() => IsEarthRoundText.BooleanQuestion(Success(), Failure());
    public static IQuestion AgeQuestion() => WhatIsYourAgeText.AgeQuestion(IsEarthRound());
    public static IQuestion NameQuestion() => WhatIsYourNameText.TextQuestion(AgeQuestion());

    IQuestion Answer(string value);
    bool IsTerminal() => false;
    void Accept(IQuestionFormatter formatter);
    void Accept(IAnswerFormatter formatter);
}

internal static class QuestionExtensions
{
    public static IQuestion TerminalQuestion(this string explanation ) => 
        new TerminalQuestion(explanation);
    
    public static IQuestion BooleanQuestion(this string question, IQuestion trueQuestion, IQuestion falseQuestion) =>
        new BooleanQuestion(question, trueQuestion, falseQuestion);
    
    public static IQuestion AgeQuestion(this string question, IQuestion nextQuestion) => 
        new NumericQuestion(question, nextQuestion);
    
    public static IQuestion TextQuestion(this string question, IQuestion nextQuestion) => 
        new TextQuestion(question, nextQuestion);
}