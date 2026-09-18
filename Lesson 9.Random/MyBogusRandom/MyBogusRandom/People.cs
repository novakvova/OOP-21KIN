namespace MyBogusRandom;

class People
{
    //Властивість, яка зберігає і змінні відразу робить get;set;
    public string FullName { get; set; } = null!;
    public int Age { get; set; }
    public string Phone { get; set; } = null!;

    public override string ToString()
    {
        return $"{FullName}\t\t{Age}\t\t{Phone}";
    }
}
