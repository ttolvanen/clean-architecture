using Domain.Exams;
using Domain.Questions;
using Domain.Tests.Questions.TestHelpers;
using Domain.Visitors;

namespace Domain.Tests;

public class TestExamAssertion(Exam exam, IEnumerable<(string expectedText, object expectedAnswer)> expectedAnswers)
    : IExamFormatter
{
    public void Assert()
    {
        exam.Accept(this);
    }
    public void VisitAnsweredQuestions(IEnumerable<IQuestion> answeredQuestions)
    {
        foreach (var( question, ( expectedQuestion, expectedAnswer )) in answeredQuestions.Zip(expectedAnswers, (question, answer) => (question, answer)))
            question.ShouldHaveQuestionAndAnswer(expectedQuestion, expectedAnswer);
    }
}