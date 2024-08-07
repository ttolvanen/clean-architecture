using Domain.Exams;
using Domain.Questions;
using Domain.Visitors;

namespace Domain.Tests.Questions.TestHelpers;

public static  class QuestionTestExtensions
{ 
    public static void ShouldHaveQuestion(this IQuestion question, string expectedQuestion) =>
        question.Accept(new TestQuestionFormatter(expectedQuestion));
   
    public static void ShouldHaveQuestionAndAnswer(this IQuestion question, string expectedText, object expectedAnswer) =>
        question.Accept(new TestAnswerFormatter(expectedText, expectedAnswer));

    public static void ShouldHaveQuestionsAndAnswers(this Exam exam,
        IEnumerable<(string expectedText, object expectedAnswer)> expectedAnswers)
    {   
        new TestExamAssertion(exam, expectedAnswers).Assert();
    }

    public static IQuestionFormatter ShouldOutput(string expectedText) => 
        new TestQuestionFormatter(expectedText);
    
    public static void ShouldNotHaveAnswer(this IQuestion question) => 
        question.Accept(new NoAnswerAssertion());
}