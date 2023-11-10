using Core.Interfaces;

namespace Core.Tests.Fakes;

public class QuestionFake(IQuestion another) : IQuestion {
    
    public IQuestion Answer(string value) => another;

    public void Accept(IQuestionFormatter formatter) => throw new NotImplementedException();

    public void Accept(IAnswerFormatter formatter) => throw new NotImplementedException();
}