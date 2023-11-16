using Core.Domain;
using Core.Interfaces;

namespace Core.Mediators;

public class IdVisitor: IIdVisitor
{
    private int _id;

    public int ToId(StudentId studentId)
    {   
        studentId.Accept(this);
        return _id;
    }

    public void Visit(int id)
    {
        _id = id;
    }
}