using Core.Domain;
using FluentAssertions;
using Infrastructure.Repositories;

namespace Infrastructure.Tests.Repositories;

public class QuestionRepositoryTests
{
    private static readonly Question NameQuestion = new("What is your name?");
    private static readonly Question AgeQuestion = new("What is your age?");

    [Fact]
    public void GetCurrentQuestion()
    {
        var repository = InMemoryQuestionRepository.Create(NameQuestion);
        repository.GetCurrentQuestion().Should().Be(NameQuestion);
        
        repository = InMemoryQuestionRepository.Create(AgeQuestion);
        repository.GetCurrentQuestion().Should().Be(AgeQuestion);
    }
    
    [Fact]
    public void UpdateCurrentQuestion()
    {
        var repository = InMemoryQuestionRepository.Create(NameQuestion);
        repository.UpdateCurrentQuestion(AgeQuestion);
        repository.GetCurrentQuestion().Should().Be(AgeQuestion);
    }
} 