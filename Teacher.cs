namespace ConsolePoly;

public class Teacher : Person
{
    private string subject;
    private decimal salary;

    public Teacher() : base()
    {
        subject = "-";
        salary = 0;
    }

    public Teacher(string name, ushort age, string subject, decimal salary) : base(name, age)
    {
        this.subject = subject;
        this.salary = salary;
    }

    public override void ViewInfo()
    {
        Console.WriteLine("--- Викладач ---");
        base.ViewInfo();
        Console.WriteLine($"Предмет: {subject}, Зарплата: {salary}");
    }

    public override void SaveToFile(StreamWriter writer)
    {
        writer.WriteLine("Teacher");
        base.SaveToFile(writer);
        writer.WriteLine(subject);
        writer.WriteLine(salary);
    }

    public override void ReadFromFile(StreamReader reader)
    {
        base.ReadFromFile(reader);
        subject = reader.ReadLine()!;
        salary = decimal.Parse(reader.ReadLine()!);
    }
}
