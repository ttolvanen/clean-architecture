using Core.Interfaces;

namespace Core.Domain;

internal class NumericQuestion : SimpleQuestion<int>
{
    public NumericQuestion(string questionText, IQuestion nextQuestion) : base(questionText, nextQuestion)
    {
        GivenAnswer = int.MinValue;
    }

    public override void Accept(IAnswerFormatter formatter)
    {
        if (GivenAnswer is int.MinValue) return;
        formatter.VisitNumericAnswer(QuestionText, GivenAnswer);
    }
}