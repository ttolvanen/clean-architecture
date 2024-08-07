namespace Domain.Visitors;

public interface IId    
{
    public void Accept(IIdVisitor visitor);
}