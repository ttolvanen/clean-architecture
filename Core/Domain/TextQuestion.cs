using Core.Interfaces;

namespace Core.Domain;

internal class TextQuestion : SimpleQuestion<string>
{
    public TextQuestion(string questionText, IQuestion nextQuestion) : base(questionText, nextQuestion)
    {
    }

    public override void Accept(IAnswerFormatter formatter)
    {
        if (GivenAnswer is null ) return;
        formatter.VisitStringAnswer(QuestionText, GivenAnswer);
    }
}