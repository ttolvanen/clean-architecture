using Core.Mediators;
using Domain.Exams;

namespace Core.Tests.Mediators;

public class ExamAssemblerTest
{
    private readonly Exam _exam = new (StudentConstants.BrianStudentId, NameQuestion());
   
    [Fact]
    public void ToDto()
    {
        ExamAssembler.CreateDto(_exam).Answers.Should().BeEmpty();
        
        _exam.Answer("Pekka");
        ExamAssembler.CreateDto(_exam).Answers.Single().Should().Be(
            new AnswerDto(WhatIsYourNameText, "Pekka"));
        
        _exam.Answer("10");
        ExamAssembler.CreateDto(_exam).Answers.Should().ContainInOrder(
            new AnswerDto(WhatIsYourNameText, "Pekka"),
            new AnswerDto(WhatIsYourAgeText, "10")
            );
    }
}