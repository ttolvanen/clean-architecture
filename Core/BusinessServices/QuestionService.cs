using Core.Dtos;
using Core.Interfaces;
using Core.Mediators;

namespace Core.BusinessServices;

/// <summary>
/// Knows how to get the next question and save the answer.
/// </summary>
public class QuestionService
{
    private readonly IQuestionRepository _repository;

    public QuestionService(IQuestionRepository repository)
    {
        _repository = repository;
    }

    public QuestionDto GetNextQuestion() => 
        QuestionMediator.CreateDto(_repository.GetCurrentQuestion());

    public QuestionDto SaveAnswer(string answer) =>
        QuestionMediator.CreateDto(
            _repository.UpdateCurrentQuestion(
                _repository.GetCurrentQuestion()
                    .Answer(answer)));
}