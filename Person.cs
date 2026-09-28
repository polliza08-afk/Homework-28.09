namespace ConsolePoly;

public class Person
{
    protected string name;
    protected ushort age;

    public Person()
    {
        name = "Невідомо";
        age = 0;
    }

    public Person(string name, ushort age)
    {
        this.name = name;
        this.age = age;
    }

    public virtual void ViewInfo()
    {
        Console.WriteLine($"Ім'я: {name}, Вік: {age}");
    }

    public virtual void SaveToFile(StreamWriter writer)
    {
        writer.WriteLine(name);
        writer.WriteLine(age);
    }

    public virtual void ReadFromFile(StreamReader reader)
    {
        name = reader.ReadLine()!;
        age = ushort.Parse(reader.ReadLine()!);
    }
}
