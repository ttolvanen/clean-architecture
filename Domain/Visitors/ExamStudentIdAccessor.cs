using Domain.Exams;

namespace Domain.Visitors;

public class ExamStudentIdAccessor : IExamVisitor
{
    public StudentId StudentId { get; private set; } = null!;
    
    public ExamStudentIdAccessor(Exam exam)
    {
        exam.Accept(this);
    }

    public void VisitId(StudentId studentId)
    {
        StudentId = studentId;
    }
}