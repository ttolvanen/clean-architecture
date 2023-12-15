using Core.Domain;

namespace Core.Interfaces;

public class ExamVisitor : IExamVisitor
{
    public StudentId? StudentId { get; private set; }
  
    public ExamVisitor(Exam exam)
    {
        exam.Accept(this);
    }

    public void VisitId(StudentId studentId)
    {
        StudentId = studentId;
    }

}