using Core.Domain;
using Core.Dtos;
using Core.Interfaces;
using static Core.Mediators.ExamAssembler;
using static Core.Mediators.QuestionMediator;

namespace Core.BusinessServices;

/// <summary>
/// Knows how to get the next question and save the answer.
/// </summary>
public class QuestionService(IQuestionRepository repository)
{
    public QuestionDto GetNextQuestion(StudentId studentId) => 
        CreateDto(repository.GetExamForStudent(studentId).GetNextQuestion());

    public QuestionDto SaveAnswer(StudentId studentId, string answer)
    {
        var exam = repository.GetExamForStudent(studentId);
        exam.Answer(answer);
        repository.UpdateExam(exam);
        return CreateDto(exam.GetNextQuestion());
    }
    
    public ExamDto GetExamSubmission(StudentId studentId) => 
        CreateDto(repository.GetExamForStudent(studentId));
}