namespace Core.Tests.Domain;

public class QuestionTests
{
    private static readonly Question NameQuestion = new ("What is your name?");
    private static readonly Question AgeQuestion = new ("What is your age?"); 
    
    [Fact]
    public void GetQuestionText()
    {
        NameQuestion.GetQuestionText().Should().Be("What is your name?");
        AgeQuestion.GetQuestionText().Should().Be("What is your age?");
    }
}