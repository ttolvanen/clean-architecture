using Core.Mediators;
using Domain.Exams;

namespace Core.Tests.Mediators;

public class IdVisitorTests
{ 
    [Fact]
    public void ToId()
    {
        new IdVisitor().ToNumber(123.StudentId()).Should().Be(123);
    }
}