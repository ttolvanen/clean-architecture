using Core.Domain;

namespace Core.BusinessServices;

public class ExamFactory(IQuestion initialQuestion)
{
    public Exam CreateExam(StudentId studentId) => new(studentId, initialQuestion);
}