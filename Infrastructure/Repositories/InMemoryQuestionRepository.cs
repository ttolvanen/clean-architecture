using Core.Domain;
using Core.Interfaces;

namespace Infrastructure.Repositories;

public class InMemoryQuestionRepository : QuestionRepository
{
    private Question _currentQuestion;
    
    private InMemoryQuestionRepository(Question initialQuestion)
    {
        _currentQuestion = initialQuestion;
    }

    public static InMemoryQuestionRepository Create(Question initialQuestion)
    {
        return new InMemoryQuestionRepository(initialQuestion);
    }
    
    public Question GetCurrentQuestion() => _currentQuestion;

    public void UpdateCurrentQuestion(Question question)
    {
        _currentQuestion = question;
    }
}