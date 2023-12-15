using Core.Domain;
using Core.Dtos;
using Core.Mediators;

namespace Infrastructure.Entities;

public class ExamEntity   
{
    public int Id { get; init; }
    public int StudentId { get; init; }
    public List<AnsweredQuestion> AnsweredQuestions { get; set; } = [];

    public void Update(Exam exam) =>
        AnsweredQuestions = 
            new ExamFormatter(exam).Answers.Select( a =>
                new AnsweredQuestion
                {
                    QuestionText = a.Question,
                    Answer = a.Answer
                }).ToList();
}