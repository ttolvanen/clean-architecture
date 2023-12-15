using Core.Domain;
using Core.Dtos;

namespace Core.Mediators;

public static class ExamAssembler
{
    public static ExamDto CreateDto(Exam exam)
    {
        var formatter = new ExamFormatter(exam);
        return new ExamDto(formatter.Answers);
    }
}