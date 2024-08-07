using Core.BusinessServices;
using Core.Tests.Fakes;
using Domain.Exams;

namespace Core.Tests.BusinessServices;

public class ExamFactoryTests
{
    private readonly QuestionFake _initialQuestion = new (Success());

    [Fact]
    public void CreateExam()
    {
        new ExamFactory(_initialQuestion)
            .CreateExam(1.StudentId()).Should().NotBeNull();
        new ExamFactory(_initialQuestion)
            .CreateExam(1.StudentId()).GetNextQuestion()
            .Should().Be(_initialQuestion);
    }
}