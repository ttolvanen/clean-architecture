using Domain.Exams;
using Domain.Visitors;

namespace Domain.Tests.Visitors;

public class ExamStudentIdAccessorTests
{
    private static readonly StudentId SomeStudentId = 123.StudentId();
    private static readonly Exam AnExam = new(SomeStudentId, Success());

    [Fact]
    public void GetStudentId()
    {
        new ExamStudentIdAccessor(AnExam).StudentId.Should().Be(SomeStudentId);
    }
}