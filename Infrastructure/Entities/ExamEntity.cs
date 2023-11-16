using Core.Dtos;

namespace Infrastructure.Entities;

public class ExamEntity   
{
    public int Id { get; set; }
    
    public int StudentId { get; set; }
    public List<AnsweredQuestion> AnsweredQuestions { get; set; }
}