using Core.BusinessServices;
using Core.Dtos;
using Core.Interfaces;
using static Core.Domain.IQuestion;

namespace Core.Tests.BusinessServices;

internal class QuestionRepositoryFake : IQuestionRepository
{
    private IQuestion _currentQuestion = NameQuestion();

    public IQuestion GetCurrentQuestion() => _currentQuestion;

    public IQuestion UpdateCurrentQuestion(IQuestion textualQuestion) => _currentQuestion = textualQuestion;
}   

public class QuestionServiceTests
{
    private readonly QuestionService _service = new(new QuestionRepositoryFake());

    [Fact]
    public void GetNextQuestion()
    {
        _service.GetNextQuestion().Should().Be(new QuestionDto("What is your name?"));
    }

    [Fact] 
    public void SaveAnswer()
    {
        _service.SaveAnswer("Brian").Should().Be(new QuestionDto("What is your age?"));
        _service.SaveAnswer("10").Should().Be(new QuestionDto("Is earth round?"));
        _service.SaveAnswer("true").Should().Be(new QuestionDto("Thank you for taking the survey!"));
    }
}