using Core.Dtos;
using Core.Mediators;

namespace Core.Tests.Mediators;

public class QuestionMediatorTests
{
    private static readonly Question Question = new ("What is your name?");

    [Fact]
    public void CreateDto()
    {
        QuestionMediator.CreateDto(Question).Should().Be(new QuestionDto("What is your name?"));
    }
}