namespace Core.Domain;

public class Question
{
    public static readonly Question NameQuestion = new ("What is your name?");
    public static readonly Question AgeQuestion = new("What is your age?");

    private readonly string _questionText;
    
    public Question(string questionText)
    {
        _questionText = questionText;
    }
    
    public string GetQuestionText() => _questionText;
}