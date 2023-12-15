using Core.BusinessServices;
using Core.Interfaces;
using Moq;
using static Core.Tests.StudentConstants;

namespace Core.Tests.BusinessServices;

public class QuestionServiceTests
{
    private readonly QuestionService _service;

    private readonly Mock<IExamRepository> _questionRepositoryMock = new();
    private readonly Exam _brianExam = new (BrianStudentId, NameQuestion());
    private readonly Exam _janeExam = new (JaneStudentId, NameQuestion());

    public QuestionServiceTests()
   {
        _questionRepositoryMock.Setup(r => r.GetExamForStudent(BrianStudentId)).Returns(_brianExam);
        _questionRepositoryMock.Setup(r => r.GetExamForStudent(JaneStudentId)).Returns(_janeExam);
        _questionRepositoryMock.Setup(r => r.UpdateExam(It.IsAny<Exam>())).Verifiable();
        
        _service = new QuestionService(_questionRepositoryMock.Object);
    }

    [Fact]
    public void NextQuestionForDifferentStudents()
    {
        _service.GetNextQuestion(BrianStudentId).Should().Be(new QuestionDto(WhatIsYourNameText));
        _service.GetNextQuestion(JaneStudentId).Should().Be(new QuestionDto(WhatIsYourNameText));
    }

    [Fact]
    public void SaveAnswer()
    {
        _service.SaveAnswer(BrianStudentId, "Brian").Should().Be(new QuestionDto("What is your age?"));
        _service.SaveAnswer(JaneStudentId, "Jane").Should().Be(new QuestionDto("What is your age?"));
        _service.SaveAnswer(BrianStudentId, "40").Should().Be(new QuestionDto("Is earth round?"));
        _service.SaveAnswer(JaneStudentId, "30").Should().Be(new QuestionDto("Is earth round?"));
        _service.SaveAnswer(BrianStudentId, "true").Should().Be(new QuestionDto("Thank you for taking the survey!"));
        _questionRepositoryMock.Verify( r => r.UpdateExam(It.IsAny<Exam>()), Times.Exactly(5));
    }

    [Fact] 
    public void GetExamResults()
    {
        _service.SaveAnswer(BrianStudentId, "Brian");
        _service.SaveAnswer(BrianStudentId, "40");
        _service.SaveAnswer(BrianStudentId, "true");
        var examResults = _service.GetExamSubmission(BrianStudentId);
        examResults.Answers.Should().HaveCount(3);
        examResults.Answers.Should().ContainInOrder(
            new AnswerDto(WhatIsYourNameText, "Brian"),
            new AnswerDto(WhatIsYourAgeText, "40"),
            new AnswerDto(IsEarthRoundText, "yes"));

        _service.GetExamSubmission(JaneStudentId).Answers.Should().BeEmpty();
    }
}