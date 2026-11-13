namespace WpfTest.Models;

public class TestItemModel
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int TimeLimitMinutes { get; set; }
    public int QuestionsCount { get; set; }
}
