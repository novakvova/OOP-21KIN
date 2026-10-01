using System.Xml.Linq;

namespace ConsolePoly;
    public class Teacher : People
    {
        public decimal Salary { get; set; }

        public Teacher() { }
        public Teacher(string name, ushort age, decimal salary) : base(name, age) => Salary = salary;

        public override void ViewInfo() => Console.WriteLine($"[Викладач] {Name}, {Age} р. | ЗП: {Salary:C0}");

        public override void Save(StreamWriter w)
        {
            base.Save(w);
            w.WriteLine(Salary);
        }

        public override void Load(StreamReader r)
        {
            base.Load(r);
            Salary = decimal.Parse(r.ReadLine()!);
        }
    }