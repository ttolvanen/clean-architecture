using Core.Mediators;

namespace Core.Tests.Mediators;

public class IdVisitorTests
{ 
    [Fact]
    public void ToId()
    {
        new IdVisitor().ToId(123.StudentId()).Should().Be(123);
    }
}