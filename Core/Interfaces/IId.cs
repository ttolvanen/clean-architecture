namespace Core.Interfaces;

public interface IId    
{
    public void Accept(IIdVisitor visitor);
}