namespace Core.Dtos;

public record ExamDto(AnswerDto[] Answers) 
{
    public ExamDto() : this([]) { }

    public override string ToString() => $"Answers: {string.Join(", ", Answers.Select(a => a.ToString()))}";
};

