namespace Core.Dtos;

public record ExamDto(AnswerDto[] Answers) 
{
    public ExamDto() : this(Array.Empty<AnswerDto>())
    {
    }
};

