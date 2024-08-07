using Domain;
using Domain.Exams;
using Domain.Questions;
using Domain.Visitors;
using FluentAssertions;
using Infrastructure.Repositories;
using static Infrastructure.Tests.StudentConstants;

namespace Infrastructure.Tests.Repositories;

public class QuestionRepositoryTests
{
  
    private class FakeQuestion : IQuestion
    {
        public IQuestion Answer(string _) => this;

        public void Accept(IQuestionFormatter formatter) {}
        public void Accept(IAnswerFormatter formatter) {}
    }
    
    private static readonly IQuestion FirstQuestion = new FakeQuestion();
    private static readonly IQuestion SecondQuestion = new FakeQuestion();
    
    private readonly IExamRepository _sut = 
        InMemoryExamRepository.CreateWithInitialQuestion(FirstQuestion);

    [Fact]
    public void GetExam()
    {
        _sut.GetExamForStudent(BrianStudentId).GetNextQuestion().Should().Be(FirstQuestion);
        _sut.GetExamForStudent(JaneStudentId).GetNextQuestion().Should().Be(FirstQuestion);
        
        InMemoryExamRepository.CreateWithInitialQuestion(SecondQuestion)
            .GetExamForStudent(JaneStudentId).GetNextQuestion().Should().Be(SecondQuestion);
    }
    
    [Fact]
    public void UpdateExam()
    {
        var exam1 = new Exam(BrianStudentId, SecondQuestion);
        var exam2 = new Exam(JaneStudentId, SecondQuestion);
        _sut.UpdateExam(exam1);
        _sut.GetExamForStudent(BrianStudentId).Should().Be(exam1);
      
        _sut.UpdateExam(exam2);
        _sut.GetExamForStudent(BrianStudentId).Should().Be(exam1);
        _sut.GetExamForStudent(JaneStudentId).Should().Be(exam2);
    }
}