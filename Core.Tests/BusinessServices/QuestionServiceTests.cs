using Core.BusinessServices;
using Core.Dtos;
using Core.Interfaces;
using Moq;

namespace Core.Tests.BusinessServices;

public class QuestionServiceTests
{
    private readonly Mock<QuestionRepository> _serviceMock;

    public QuestionServiceTests()
    {
        _serviceMock = new Mock<QuestionRepository>();
        _serviceMock.Setup(s => s.GetCurrentQuestion()).Returns(Question.NameQuestion);
    }
    [Fact]
    public void GetNextQuestion()
    {
        var service = new QuestionService(_serviceMock.Object);
        service.GetNextQuestion().Should().Be(new QuestionDto("What is your name?"));
    }
    
    [Fact]
    public void SaveAnswer()
    {
        var service = new QuestionService(_serviceMock.Object);
        service.SaveAnswer("Brian").Should().Be(new QuestionDto("What is your name?"));
        
    }
}