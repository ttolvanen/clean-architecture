using Core.Interfaces;
using Moq;

namespace Core.Tests.Domain;

public class StudentIdTests
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(1000)]
    [InlineData(10000)]
    public void ValidNumbers(int number)
    {
        var action = () => number.StudentId();
        action.Should().NotThrow();
    }
    
    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(10001)]
    [InlineData(20000)]
    public void InvalidNumbers(int number)
    {
        var action = () => number.StudentId();
        action.Should().Throw<ArgumentException>();
    }
    
    [Fact]
    public void Equality()
    {
        1.StudentId().Should().Be(1.StudentId());
        1.StudentId().Should().NotBe(2.StudentId());
        
        1.StudentId().Equals(1.StudentId()).Should().BeTrue();
        2.StudentId().Equals(1.StudentId()).Should().BeFalse();
        
        2.StudentId().Equals(1.StudentId()).Should().BeFalse();
    }
    
    [Fact]
    public void HashCode()
    {
        1.StudentId().GetHashCode().Should().Be(1.StudentId().GetHashCode());
        1.StudentId().GetHashCode().Should().NotBe(2.StudentId().GetHashCode());
    }

    [Theory]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(10000)]
    public void VisitIdVisitor(int expectedId)
    {
        var mockVisitor = new Mock<IIdVisitor>();
        mockVisitor.Setup(v => v.Visit(It.IsAny<int>()))
            .Callback((int id) => id.Should().Be(expectedId) );

        expectedId.StudentId().Accept(mockVisitor.Object);
    }
}
