using Core.Tests.Fakes;
using Domain.Exams;
using Domain.Questions;
using Domain.Tests.Questions.TestHelpers;

namespace Domain.Tests;

public class ExamTests
{
    private static readonly IQuestion AnotherFakeQuestion = new QuestionFake(Success());
    private static readonly IQuestion FakeQuestion = new QuestionFake(AnotherFakeQuestion);
    private static readonly Exam FinishedExam = new (1.StudentId(), Success());
     
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
        _exam.ShouldHaveQuestionsAndAnswers([("QuestionFake", "Brian")]);
    }

    [Fact]
    public void Matches()
    {
        _exam.IsForStudent(1.StudentId()).Should().BeTrue();
        _exam.IsForStudent(2.StudentId()).Should().BeFalse();
        FinishedExam.IsForStudent(1.StudentId()).Should().BeTrue();
    }
    
}


