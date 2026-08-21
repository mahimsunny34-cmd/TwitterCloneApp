using System.Security.Cryptography.X509Certificates;
using TwitterClone.Domain.Entities;

public class Run
{
    public static void Main(string[] args)
    {
        var objects = new List<Notification>
        {
            new LikeNotification(Guid.NewGuid()),
            new CommentNotification(Guid.NewGuid()),
            new FriendRequestNotification(Guid.NewGuid()),
            new SystemNotification("system notification"),
            new MentionNotification(Guid.NewGuid()),
        };

        foreach (var obj in objects)
        {
            Console.WriteLine(obj.GetMessage(),
            obj.PrintNotification());
        }
    }
}
