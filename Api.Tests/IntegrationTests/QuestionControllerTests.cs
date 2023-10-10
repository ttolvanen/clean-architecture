using Core.BusinessServices;
using Core.Domain;
using Core.Dtos;
using FluentAssertions;
using Infrastructure.Repositories;
using Microsoft.Extensions.Logging.Abstractions;

namespace Api.Tests.IntegrationTests;
using Controllers;

public class QuestionControllerTests
{
    private readonly QuestionsController _controller = new (
        new NullLogger<QuestionsController>(), 
        new QuestionService(InMemoryQuestionRepository.Create(Question.NameQuestion)));

    [Fact]
    public void GetNextQuestion()
    {
        _controller.GetNextQuestion().Should().Be(new QuestionDto("What is your name?"));
    }
    
    [Fact]
    public void SaveAnswer()
    {
        _controller.SaveAnswer("Brian").Should().Be(new QuestionDto("What is your age?"));
    }
}