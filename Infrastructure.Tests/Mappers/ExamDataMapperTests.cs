using Core.BusinessServices;
using Core.Domain;
using Core.Tests.Domain;
using FluentAssertions;
using Infrastructure.Entities;
using Infrastructure.Mappers;
using static Core.QuestionConstants;

namespace Infrastructure.Tests.Mappers;

public class ExamDataMapperTests
{
    private ExamFactory examFactory = new (IQuestion.NameQuestion());
    private readonly ExamEntity _examEntity = new ()
    {
        Id = 1,
        AnsweredQuestions = [ 
            new AnsweredQuestion
            {
                QuestionText = WhatIsYourNameText, 
                Answer = "Jake"
            },
            new AnsweredQuestion
            {
                QuestionText = WhatIsYourAgeText, 
                Answer = "22"
            }
        ],
        StudentId = 123,
    };

    [Fact]
    public void ToDomainModel()
    {
        var mapper = new ExamDataMapper(examFactory);
        var exam = mapper.ToDomainModel(_examEntity);

        exam.ShouldHaveQuestionsAndAnswers([
            (WhatIsYourNameText, "Jake"),
            (WhatIsYourAgeText, 22) ]
        );
    }
}