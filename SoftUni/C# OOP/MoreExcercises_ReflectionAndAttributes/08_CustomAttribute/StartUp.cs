using System;

[SoftUni("Ventci")]
public class StartUp
{
    [SoftUni("Gosho")]
    public static void Main(string[] args)
    {
        var tracker = new Tracker();
        tracker.PrintMethodsByAuthor();
    }
}
