using Domain;
using Domain.Exams;
using Domain.Questions;
using Domain.Visitors;

namespace Infrastructure.Repositories;

public class InMemoryExamRepository : IExamRepository
{
    private readonly IQuestion _initialQuestion;
    private List<Exam> _exams = []; 
    
    private InMemoryExamRepository(IQuestion initialQuestion) => _initialQuestion = initialQuestion;

    public static IExamRepository CreateWithInitialQuestion(IQuestion initialTextualQuestion) => 
        new InMemoryExamRepository(initialTextualQuestion);

    public Exam GetExamForStudent(StudentId studentId)
    {
        if(!_exams.Any(e => e.IsForStudent(studentId))) _exams.Add(new Exam(studentId, _initialQuestion));
        return _exams.First(e => e.IsForStudent(studentId));
    }
    
    public void UpdateExam(Exam exam) => _exams = _exams.Where( e => !e.Equals(exam)).Append(exam).ToList();
}