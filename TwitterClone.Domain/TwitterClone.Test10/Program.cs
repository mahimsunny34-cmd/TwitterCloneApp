using TwitterClone.Domain.Entities;

public class Run
{
    public static void Main(String[] args)
    {
        Tweet tweet1 = new("This is my new content", Guid.NewGuid());
        Console.WriteLine(tweet1.DescribeRecord());
    }
}