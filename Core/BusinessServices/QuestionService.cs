using Core.Domain;
using Core.Dtos;
using Core.Interfaces;
using Core.Mediators;

namespace Core.BusinessServices;

/// <summary>
/// Knows how to get the next question and save the answer.
/// </summary>
public class QuestionService(IExamRepository repository)
{
    public QuestionDto GetNextQuestion(StudentId studentId) => 
        QuestionAssembler.CreateDto(repository.GetExamForStudent(studentId).GetNextQuestion());

    public QuestionDto SaveAnswer(StudentId studentId, string answer)
    {
        var exam = repository.GetExamForStudent(studentId);
        exam.Answer(answer);
        repository.UpdateExam(exam);
        return QuestionAssembler.CreateDto(exam.GetNextQuestion());
    }
    
    public ExamDto GetExamSubmission(StudentId studentId) => 
        ExamAssembler.CreateDto(repository.GetExamForStudent(studentId));
}