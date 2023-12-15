using Core.Domain;

namespace Core.Interfaces;

public interface IExamVisitor
{
    void VisitId(StudentId studentId);
}