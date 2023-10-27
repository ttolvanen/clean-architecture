using Core.Domain;

namespace Core.Interfaces;

public interface IQuestionRepository
{
    IQuestion GetCurrentQuestion();

    IQuestion UpdateCurrentQuestion(IQuestion textualQuestion);
} 