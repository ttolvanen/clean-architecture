using Core.Dtos;
using Domain;
using Domain.Exams;

namespace Core.Mediators;

public static class ExamAssembler
{
    public static ExamDto CreateDto(Exam exam) => new(ExamAnswerFormatter.ExtractAnswers(exam));
   
}