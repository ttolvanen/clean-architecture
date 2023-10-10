using Core.Domain;

namespace Core.Interfaces;

public interface QuestionRepository
{
    Question GetCurrentQuestion();

    void UpdateCurrentQuestion(Question question);
} 