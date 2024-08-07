namespace Infrastructure.Entities;

public class AnsweredQuestion
{
    protected AnsweredQuestion()
    {
        QuestionText = null!;
        Answer = null!;
    }

    public AnsweredQuestion(string questionText, string answer) : this()
    {
        QuestionText = questionText;
        Answer = answer;
    }

    public string QuestionText { get; set; }
    public string Answer { get; set; }
}