using Core.Domain;
using FluentAssertions;
using Infrastructure.Repositories;

namespace Infrastructure.Tests.Repositories;

public class QuestionRepositoryTests
{
  
    private class FakeQuestion : IQuestion
    {
       public IQuestion Answer(string value) => throw new NotImplementedException();

       public void Accept(QuestionPrinter printer) => throw new NotImplementedException();
    }
    
    private readonly IQuestion firstQuestion = new FakeQuestion();
    private readonly IQuestion secondQuestion = new FakeQuestion();
    
    [Fact]
    public void GetCurrentQuestion()
    {
        var repository = InMemoryQuestionRepository.CreateWithInitialQuestion(firstQuestion);
        repository.GetCurrentQuestion().Should().Be(firstQuestion);
        
        repository = InMemoryQuestionRepository.CreateWithInitialQuestion(secondQuestion);
        repository.GetCurrentQuestion().Should().Be(secondQuestion);
    }
    
    [Fact]
    public void UpdateCurrentQuestion()
    {
        var repository = InMemoryQuestionRepository.CreateWithInitialQuestion(firstQuestion);
        repository.UpdateCurrentQuestion(secondQuestion);
        repository.GetCurrentQuestion().Should().Be(secondQuestion);
    }
} 

