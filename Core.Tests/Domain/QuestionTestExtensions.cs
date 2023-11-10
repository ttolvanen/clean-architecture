using Core.Interfaces;

namespace Core.Tests.Domain;

internal static  class QuestionTestExtensions
{ 
    public static void ShouldHaveQuestion(this IQuestion question, string expectedQuestion) =>
        question.Accept(new TestQuestionFormatter(expectedQuestion));
   
    public static void ShouldHaveQuestionAndAnswer(this IQuestion question, string expectedText, object expectedAnswer) =>
        question.Accept(new TestAnswerFormatter(expectedText, expectedAnswer));
    
    public static IQuestionFormatter ShouldOutput(string expectedText) => 
        new TestQuestionFormatter(expectedText);
    
    public static void ShouldNotHaveAnswer(this IQuestion question) => 
        question.Accept(new NoAnswerVisitor());
}