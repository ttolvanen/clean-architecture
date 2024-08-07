using Core.BusinessServices;
using Domain.Exams;
using Domain.Questions;
using Domain.Tests;
using Domain.Tests.Questions.TestHelpers;
using Domain.Visitors;
using FluentAssertions;
using Infrastructure.Entities;
using Infrastructure.Mappers;
using static Domain.Questions.QuestionConstants;

namespace Infrastructure.Tests.Mappers;

public class ExamEntityMapperTests
{
    private static readonly ExamFactory ExamFactory = new (IQuestion.NameQuestion());
    private static readonly ExamEntity ExamEntity = new ()
    {
        Id = 1,
        AnsweredQuestions = [
            new AnsweredQuestion(questionText: WhatIsYourNameText, answer: "Jake"),
            new AnsweredQuestion(questionText: WhatIsYourAgeText, answer: "22")
        ],
        StudentId = 123,
    };

    [Fact]
    public void ToDomainModel()
    {
        var mapper = new ExamEntityMapper(ExamFactory);
        var exam = mapper.ToDomainModel(ExamEntity);

        exam.ShouldHaveQuestionsAndAnswers([
            (WhatIsYourNameText, "Jake"),
            (WhatIsYourAgeText, 22) ]
        );
        
        new ExamStudentIdAccessor(exam).StudentId.Should().Be(123.StudentId());
    }
    
    [Fact]
    public void CreateEntity()
    {
        var exam = new Exam(123.StudentId(), IQuestion.NameQuestion());
        exam.Answer("Jake");
        
        var examEntity = ExamEntityMapper.CreateEntity(123.StudentId(), exam);
        
        ShouldHaveQuestionsAndAnswersForCorrectStudent(examEntity);
    }

    private static void ShouldHaveQuestionsAndAnswersForCorrectStudent(ExamEntity examEntity)
    {
        examEntity.StudentId.Should().Be(123);
        examEntity.AnsweredQuestions.Should().NotBeEmpty();
        examEntity.AnsweredQuestions.Should().HaveCount(1);
        examEntity.AnsweredQuestions[0].QuestionText.Should().Be(WhatIsYourNameText);
        examEntity.AnsweredQuestions[0].Answer.Should().Be("Jake");
    }
}