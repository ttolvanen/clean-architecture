using Core.BusinessServices;
using Core.Dtos;
using FluentAssertions;
using FluentAssertions.Primitives;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using static Domain.Questions.IQuestion;
using static Domain.Questions.QuestionConstants;

namespace Api.Tests.IntegrationTests;
using Controllers;

public class ExamControllerTests
{
    private const int BrianStudentId = 2;

    private readonly ExamController _controller =
        new (
            NullLogger<ExamController>.Instance,
            new QuestionService(InMemoryExamRepository.CreateWithInitialQuestion(NameQuestion()))
        );

    [Fact]
    public void GetNextQuestion()
    {
        _controller.GetNextQuestion(BrianStudentId).Should().BeOkWithValue(new QuestionDto(WhatIsYourNameText));
        _controller.GetNextQuestion(BrianStudentId).Should().BeOkWithValue(new QuestionDto(WhatIsYourNameText));
    }

    [Fact]
    public void SaveAnswer()
    {
        _controller.SaveAnswer(BrianStudentId, "Brian").Should().BeOkWithValue(new QuestionDto("What is your age?"));
        _controller.SaveAnswer(BrianStudentId, "10").Should().BeOkWithValue(new QuestionDto("Is earth round?"));
        _controller.SaveAnswer(BrianStudentId, "yes").Should().BeOkWithValue(new QuestionDto("Thank you for taking the survey!"));
    }

    [Fact]
    public void FailingAnswer()
    {
        _controller.SaveAnswer(BrianStudentId, "Brian");
        _controller.SaveAnswer(BrianStudentId, "a")
            .Should()
            .BeBadRequestWithValue("Answer should be of type Int32");
    }

    [Fact]
    public void Answers()
    {
        _controller.SaveAnswer(BrianStudentId, "Brian").Should().BeOkWithValue(new QuestionDto("What is your age?"));
        _controller.SaveAnswer(BrianStudentId, "10").Should().BeOkWithValue(new QuestionDto("Is earth round?"));
        _controller.SaveAnswer(BrianStudentId, "yes").Should().BeOkWithValue(new QuestionDto("Thank you for taking the survey!"));
        _controller.Answers(BrianStudentId).Should().BeOkWithValue(
            new ExamDto([
                new AnswerDto("What is your name?", "Brian"),
                new AnswerDto("What is your age?", "10"),
                new AnswerDto("Is earth round?", "yes")
            ]));
    }
    
    [Fact]
    public void NoAnswers()
    {
        _controller.Answers(BrianStudentId).Should().BeOkWithValue(
            new ExamDto());
    }
    
    [Fact]
    public void InvalidStudentId()
    {
        _controller.GetNextQuestion(999999999)
            .Should().BeBadRequestWithValue("Student number must be between 1 and 10 000.");
        _controller.SaveAnswer(999999999, "Brian")
            .Should().BeBadRequestWithValue("Student number must be between 1 and 10 000.");
        _controller.Answers(999999999).Should()
            .BeBadRequestWithValue("Student number must be between 1 and 10 000.");
    }
}

public static class TestExtensions
{
    public static void BeOkWithValue(this ObjectAssertions result, object value)
        => result.BeAssignableTo<OkObjectResult>().Subject.Value.Should().BeEquivalentTo(value);
    
    public static void BeBadRequestWithValue(this ObjectAssertions result, object value)
        => result.BeAssignableTo<BadRequestObjectResult>().Subject.Value.Should().BeEquivalentTo(value);
}
