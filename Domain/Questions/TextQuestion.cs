using Domain.Visitors;

namespace Domain.Questions;

internal class TextQuestion : SimpleQuestion<string>
{
    internal TextQuestion(string questionText, IQuestion nextQuestion) : base(questionText, nextQuestion)
    {
    }

    public override void Accept(IAnswerFormatter formatter)
    {
        if (GivenAnswer is null ) return;
        formatter.Format(QuestionText, GivenAnswer);
    }
}