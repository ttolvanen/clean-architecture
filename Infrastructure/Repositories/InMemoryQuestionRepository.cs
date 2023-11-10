using Core.Domain;
using Core.Interfaces;

namespace Infrastructure.Repositories;

public class InMemoryQuestionRepository : IQuestionRepository
{
    private readonly IQuestion _initialQuestion;
    private List<Exam> _exams = new(); 
    
    private InMemoryQuestionRepository(IQuestion initialQuestion) => _initialQuestion = initialQuestion;

    public static InMemoryQuestionRepository CreateWithInitialQuestion(IQuestion initialTextualQuestion) => 
        new (initialTextualQuestion);

    public Exam GetExamForStudent(StudentId studentId)
    {
        if(!_exams.Any(e => e.IdMatches(studentId))) _exams.Add(new Exam(studentId, _initialQuestion));
        return _exams.First(e => e.IdMatches(studentId));
    }
    
    public void UpdateExam(Exam exam) => _exams = _exams.Where( e => !e.Equals(exam)).Append(exam).ToList();
}