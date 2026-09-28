namespace ConsolePoly;

public class Student : Person
{
    private string group;
    private double grade;

    public Student() : base()
    {
        group = "-";
        grade = 0;
    }

    public Student(string name, ushort age, string group, double grade) : base(name, age)
    {
        this.group = group;
        this.grade = grade;
    }

    public override void ViewInfo()
    {
        Console.WriteLine("--- Студент ---");
        base.ViewInfo();
        Console.WriteLine($"Група: {group}, Середній бал: {grade}");
    }

    public override void SaveToFile(StreamWriter writer)
    {
        writer.WriteLine("Student");
        base.SaveToFile(writer);
        writer.WriteLine(group);
        writer.WriteLine(grade);
    }

    public override void ReadFromFile(StreamReader reader)
    {
        base.ReadFromFile(reader);
        group = reader.ReadLine()!;
        grade = double.Parse(reader.ReadLine()!);
    }
}
