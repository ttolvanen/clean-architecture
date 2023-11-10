namespace Core.Interfaces;

public interface IAnswerFormatter
{
    void VisitStringAnswer(string questionText, string answer);
    void VisitYesNoAnswer(string questionText, bool answer);
    void VisitNumericAnswer(string questionText, int answer);
}