using Domain.Visitors;

namespace Domain.Questions;

// Understands a question that expects a numeric answer.
internal class NumericQuestion : SimpleQuestion<int>
{
    private const int UndefinedAnswer = int.MinValue;

    public NumericQuestion(string questionText, IQuestion nextQuestion) : base(questionText, nextQuestion)
    {
        GivenAnswer = UndefinedAnswer;
    }

    public override void Accept(IAnswerFormatter formatter)
    {
        if (GivenAnswer is UndefinedAnswer) return;
        formatter.Format(QuestionText, GivenAnswer);
    }
}