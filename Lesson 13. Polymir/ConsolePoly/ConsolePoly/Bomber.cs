namespace ConsolePoly;

public class Bomber : Worker
{
    private int _countSpam;

    public override void ViewInfo()
    {
        base.ViewInfo();
        Console.WriteLine($"Count Spam {_countSpam}");
    }
}
