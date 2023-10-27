using Core.Domain;
using Core.Interfaces;

namespace Infrastructure.Repositories;

public class InMemoryQuestionRepository : IQuestionRepository
{
    private IQuestion _currentTextualQuestion;
    
    private InMemoryQuestionRepository(IQuestion initialTextualQuestion)
    {
        _currentTextualQuestion = initialTextualQuestion;
    }

    public static InMemoryQuestionRepository CreateWithInitialQuestion(IQuestion initialTextualQuestion)
    {
        return new InMemoryQuestionRepository(initialTextualQuestion);
    }
    
    public IQuestion GetCurrentQuestion() => _currentTextualQuestion;

    public IQuestion UpdateCurrentQuestion(IQuestion textualQuestion)
    {
        _currentTextualQuestion = textualQuestion;
        return GetCurrentQuestion();
    }
}