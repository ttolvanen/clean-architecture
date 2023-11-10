using Core.Domain;

namespace Core.Interfaces;

public interface IQuestionRepository
{
    Exam GetExamForStudent(StudentId studentId);

    void UpdateExam(Exam exam);
}
 