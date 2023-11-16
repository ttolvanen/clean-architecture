using Core.BusinessServices;
using Core.Dtos;
using FluentAssertions;
using FluentAssertions.Primitives;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using static Core.Domain.IQuestion;

namespace Api.Tests.IntegrationTests;
using Controllers;

public class QuestionControllerTests
{
    private readonly QuestionsController _controller =
        new (
            NullLogger<QuestionsController>.Instance,
            new QuestionService(InMemoryExamRepository.CreateWithInitialQuestion(NameQuestion()))
        );

    [Fact]
    public void GetNextQuestion()
    {
        _controller.GetNextQuestion(2).Should().BeOkWithValue(new QuestionDto("What is your name?"));
        _controller.GetNextQuestion(2).Should().BeOkWithValue(new QuestionDto("What is your name?"));
    }

    [Fact]
    public void SaveAnswer()
    {
        _controller.SaveAnswer(2, "Brian").Should().BeOkWithValue(new QuestionDto("What is your age?"));
        _controller.SaveAnswer(2, "10").Should().BeOkWithValue(new QuestionDto("Is earth round?"));
        _controller.SaveAnswer(2, "yes").Should().BeOkWithValue(new QuestionDto("Thank you for taking the survey!"));
    }

    [Fact]
    public void FailingAnswer()
    {
        _controller.SaveAnswer(2, "Brian");
        _controller.SaveAnswer(2, "a")
            .Should()
            .BadRequestWithValue("Answer should be of type Int32");
    }
}

public static class TestExtensions
{
    public static void BeOkWithValue(this ObjectAssertions result, object value)
        => result.BeAssignableTo<OkObjectResult>().Subject.Value.Should().Be(value);
    
    public static void BadRequestWithValue(this ObjectAssertions result, object value)
        => result.BeAssignableTo<BadRequestObjectResult>().Subject.Value.Should().Be(value);
}
