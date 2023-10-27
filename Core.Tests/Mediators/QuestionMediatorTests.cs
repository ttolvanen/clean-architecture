using Core.Dtos;
using Core.Mediators;
using static Core.Domain.IQuestion;

namespace Core.Tests.Mediators;

public class QuestionMediatorTests
{
    [Fact]
    public void CreateDto()
    {
        QuestionMediator.CreateDto(NameQuestion()).Should().Be(new QuestionDto("What is your name?"));
    }
}