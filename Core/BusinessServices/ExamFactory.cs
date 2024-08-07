using Domain;
using Domain.Exams;
using Domain.Questions;

namespace Core.BusinessServices;

public class ExamFactory(IQuestion initialQuestion)
{
    public Exam CreateExam(StudentId studentId) => new(studentId, initialQuestion);
}