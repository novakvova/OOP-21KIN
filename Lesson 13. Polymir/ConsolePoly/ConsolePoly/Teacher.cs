namespace ConsolePoly;

public class Teacher : Worker
{
    private string _position;
    private decimal _salary;

    public Teacher()
    {
        _position = "No position";
        _salary = 0.0M;
    }
    //override - це метод буде перевантажений, бо у 
    //батьківському класі є слова virtual
    public override void ViewInfo()
    {
        base.ViewInfo(); //Викликаємо батьківський метод
        Console.WriteLine($"Position: {_position}");
        Console.WriteLine($"Salary: {_salary}");
    }
}
