using Core.Domain;
using Core.Dtos;

namespace Core.Mediators;

public static class QuestionMediator
{
    public static QuestionDto CreateDto(IQuestion question)
    {
        var printer = new QuestionPrinterImplementation();
        question.Accept(printer);
        return new QuestionDto(printer.Question);
    }

    private class QuestionPrinterImplementation : QuestionPrinter
    {
        public string Question { get; private set; } = string.Empty;
        public void VisitPrintText(string question) => Question = question;
    }
        
}

