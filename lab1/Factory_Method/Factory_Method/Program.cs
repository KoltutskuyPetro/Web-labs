using System;

public interface IMessage
{
    void Send(string recipient, string content);
}

public class SMSMessage : IMessage
{
    public void Send(string recipient, string content)
    {
        Console.WriteLine($"Sent SMS to {recipient}: {content}");
    }
}

public class EmailMessage : IMessage
{
    public void Send(string recipient, string content)
    {
        Console.WriteLine($"Sent Email to {recipient}: {content}");
    }
}

public abstract class MessageCreator
{
    public abstract IMessage CreateMessage();
}

public class SMSMessageCreator : MessageCreator
{
    public override IMessage CreateMessage()
    {
        return new SMSMessage();
    }
}

public class EmailMessageCreator : MessageCreator
{
    public override IMessage CreateMessage()
    {
        return new EmailMessage();
    }
}

class Program
{
    static void Main()
    {
        MessageCreator creator;

        creator = new SMSMessageCreator();
        IMessage sms = creator.CreateMessage();
        sms.Send("+380123456789", "Hello! SMS.");

        creator = new EmailMessageCreator();
        IMessage email = creator.CreateMessage();
        email.Send("user@example.com", "Hello! Email.");

        Console.ReadLine();
    }
}
