using Domain.Questions;
using Domain.Visitors;

namespace Core.Tests.Fakes;

public class QuestionFake(IQuestion another) : IQuestion
{
    private string userValue = "";

    public IQuestion Answer(string value)
    {
        userValue = value;
        return another;
    }

    public void Accept(IQuestionFormatter formatter) => throw new NotImplementedException();

    public void Accept(IAnswerFormatter formatter) => formatter.Format(nameof(QuestionFake), userValue);
}