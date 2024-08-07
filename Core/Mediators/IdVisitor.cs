using Domain.Exams;
using Domain.Visitors;

namespace Core.Mediators;

public class IdVisitor: IIdVisitor
{
    private int _id;

    public int ToNumber(StudentId studentId)
    {   
        studentId.Accept(this);
        return _id;
    }

    public void Visit(int id)
    {
        _id = id;
    }
}