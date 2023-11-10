using Core.Interfaces;

namespace Core.Domain;

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
    public static IQuestion Failure() => "The survey has failed.".TerminalQuestion();   
    public static IQuestion Success() => "Thank you for taking the survey!".TerminalQuestion();
    public static IQuestion IsEarthRound() => "Is earth round?".BooleanQuestion(Success(), Failure());
    public static IQuestion AgeQuestion() => "What is your age?".AgeQuestion(IsEarthRound());
    public static IQuestion NameQuestion() => "What is your name?".TextQuestion(AgeQuestion());

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