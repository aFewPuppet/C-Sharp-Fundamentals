namespace GradeBook
{
    public interface IBookInterface
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name {get;}
        event GradeAddedDelegate GradeAdded;
    }
}