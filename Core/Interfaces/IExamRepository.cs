using Core.Domain;

namespace Core.Interfaces;

public interface IExamRepository
{
    Exam GetExamForStudent(StudentId studentId);

    void UpdateExam(Exam exam);
}
 