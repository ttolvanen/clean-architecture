using Domain.Visitors;

namespace Domain.Exams;

public record StudentId : IId
{
    private readonly int _number;

    internal StudentId(int number)
    {
        if(number is < 1 or > 10000) throw new ArgumentException("Student number must be between 1 and 10 000."); 
        _number = number;
    }
    public override string ToString() => $"{nameof(StudentId)}({_number})".ToString();

    public void Accept(IIdVisitor visitor) => visitor.Visit(_number);
}

public static class StudentIdExtensions {
    
    public static StudentId StudentId(this int number) => new (number);
}