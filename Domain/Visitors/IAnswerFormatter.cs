namespace Domain.Visitors;

public interface IAnswerFormatter
{
    void Format(string questionText, string answer);
    void Format(string questionText, bool answer);
    void Format(string questionText, int answer);
}