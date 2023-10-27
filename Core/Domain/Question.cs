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
    public static IQuestion Failure() => new TerminalQuestion("The survey has failed.");   
    public static IQuestion Success() => new TerminalQuestion("Thank you for taking the survey!");
    public static IQuestion IsEarthRound() => new BooleanQuestion("Is earth round?", Success(), Failure());
    public static IQuestion AgeQuestion() => new SimpleQuestion<int>("What is your age?", IsEarthRound());
    public static IQuestion NameQuestion() => new SimpleQuestion<string>("What is your name?", AgeQuestion());

    IQuestion Answer(string value);
    bool IsTerminal() => false;
    void Accept(QuestionPrinter printer);
}