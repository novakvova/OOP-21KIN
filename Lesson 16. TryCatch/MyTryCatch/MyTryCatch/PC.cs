namespace MyTryCatch;

public class PC : Electronic
{
    private string _format;
    //ctor
    public PC()
    {
        _format = "ATX";        
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Format: {_format}");
    }
}
