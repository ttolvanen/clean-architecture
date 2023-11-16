using Core.Interfaces;
using Core.Tests.Fakes;

namespace Core.Tests.Domain;

public class ExamTests
{
    private static readonly IQuestion AnotherFakeQuestion = new QuestionFake(IQuestion.Success());
    private static readonly IQuestion FakeQuestion = new QuestionFake(AnotherFakeQuestion);
    private static readonly Exam FinishedExam = new (1.StudentId(), IQuestion.Success());
     
    private readonly Exam _exam = new (1.StudentId(), FakeQuestion);

    [Fact]
    public void IsReady()
    {
         FinishedExam.IsReady().Should().BeTrue();  
        _exam.IsReady().Should().BeFalse();
    }
    
    [Fact]
    public void Answering()
    {
        _exam.Answer("Brian");
        _exam.GetNextQuestion().Should().Be(AnotherFakeQuestion);
    }

    [Fact]
    public void Matches()
    {
        _exam.IdMatches(1.StudentId()).Should().BeTrue();
        _exam.IdMatches(2.StudentId()).Should().BeFalse();
        FinishedExam.IdMatches(1.StudentId()).Should().BeTrue();
    }
}


