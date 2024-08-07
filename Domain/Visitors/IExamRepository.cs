using Domain.Exams;

namespace Domain.Visitors;

public interface IExamRepository
{
    Exam GetExamForStudent(StudentId studentId);

    void UpdateExam(Exam exam);
}
 