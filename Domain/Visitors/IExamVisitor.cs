using Domain.Exams;

namespace Domain.Visitors;

public interface IExamVisitor
{
    void VisitId(StudentId studentId);
}