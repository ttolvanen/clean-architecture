using Domain.Exams;
using Domain.Questions;
using FluentAssertions;
using Infrastructure.Entities;

namespace Infrastructure.Tests.Entities;

public class ExamEntityTests
{
    [Fact]
    public void Update()
    {
        var exam = new Exam(123.StudentId(), IQuestion.NameQuestion());
        exam.Answer("Jake");

        var examEntity = new ExamEntity { Id = 200 };
        examEntity.Update(exam);

        examEntity.Id.Should().Be(200);
        examEntity.AnsweredQuestions.Should().NotBeEmpty();
        examEntity.AnsweredQuestions.Should().HaveCount(1);
        examEntity.AnsweredQuestions[0].QuestionText.Should().Be(QuestionConstants.WhatIsYourNameText);
        examEntity.AnsweredQuestions[0].Answer.Should().Be("Jake");
    }
}