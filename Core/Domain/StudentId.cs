using Microsoft.VisualBasic.CompilerServices;

namespace Core.Domain;

public record StudentId
{
    private readonly int _number;

    internal StudentId(int number)
    {
        if(number is < 1 or > 10000) throw new ArgumentException("Student number must be between 1 and 10 000."); 
        _number = number;
    }
    public override string ToString() => $"{nameof(StudentId)}({_number})".ToString();
}

public static class StudentIdExtensions {
    
    public static StudentId StudentId(this int number) => new (number);
}