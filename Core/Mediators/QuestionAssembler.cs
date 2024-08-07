using Core.Dtos;
using Domain.Questions;
using Domain.Visitors;

namespace Core.Mediators;

public static class QuestionAssembler
{
    public static QuestionDto CreateDto(IQuestion question)
    {
        var printer = new QuestionFormatterImplementation();
        question.Accept(printer);
        return new QuestionDto(printer.Question);
    }

    private class QuestionFormatterImplementation : IQuestionFormatter
    {
        public string Question { get; private set; } = string.Empty;
        public void Format(string question) => Question = question;
    }
}

