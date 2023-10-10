using Core.Dtos;
using Core.Interfaces;

namespace Core.BusinessServices;

public class QuestionService
{
    private readonly QuestionRepository _repository;

    public QuestionService(QuestionRepository repository)
    {
        _repository = repository;
    }
    
    public QuestionDto GetNextQuestion()
    {
        throw new NotImplementedException();
    }

    public QuestionDto SaveAnswer(string answer)
    {
        throw new NotImplementedException();
    }
}