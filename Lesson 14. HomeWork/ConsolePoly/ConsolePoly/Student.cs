using System.Xml.Linq;
namespace ConsolePoly;
    public class Student : People
    {
        public double Rating { get; set; }

        public Student() { }
        public Student(string name, ushort age, double rating) : base(name, age) => Rating = rating;

        public override void ViewInfo() => Console.WriteLine($"[Студент] {Name}, {Age} р. | Сер. бал: {Rating:F1}");

        public override void Save(StreamWriter w)
        {
            base.Save(w);
            w.WriteLine(Rating);
        }

        public override void Load(StreamReader r)
        {
            base.Load(r);
            Rating = double.Parse(r.ReadLine()!);
        }
    }