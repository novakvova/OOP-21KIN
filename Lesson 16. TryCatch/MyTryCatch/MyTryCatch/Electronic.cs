

namespace MyTryCatch;

public abstract class Electronic
{
    private string _cpu;
    private string _memory;
    private string _ssd;
    //ctor
    public Electronic()
    {
        _cpu = "No CPU";
        _memory = "No Memory";
        _ssd = "No SSD";
    }

    public Electronic(string cpu, 
        string memory, string ssd)
    {
        _cpu = cpu;
        _memory = memory;
        _ssd=ssd;
    }

    public virtual void PrintInfo()
    {
        //Буде виникати помилка
        throw new NotImplementedException();
    }
}
