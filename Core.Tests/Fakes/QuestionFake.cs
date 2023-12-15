using Core.Interfaces;

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

    public void Accept(IAnswerFormatter formatter) => formatter.VisitStringAnswer(nameof(QuestionFake), userValue);
}