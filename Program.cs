// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsolePoly
{
    internal class Program
    {
        static void Main()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            string fileName = "data.txt";

            //Створюємо масив на 10 елементів
            Person[] people = new Person[10];
            Random rnd = new Random();

            string[] names = { "Олександр", "Марія", "Дмитро", "Олена", "Андрій" };
            string[] subjects = { "Математика", "Фізика", "Програмування" };
            string[] groups = { "КН-11", "ПІ-21", "ІПЗ-31" };

            //Заповнюємо випадковими об'єктами
            for (int i = 0; i < 10; i++)
            {
                string name = names[rnd.Next(names.Length)];

                if (rnd.Next(2) == 0)
                {
                    //Студент
                    people[i] = new Student(name, (ushort)rnd.Next(17, 25), groups[rnd.Next(groups.Length)], 85.5);
                }
                else
                {
                    //Викладач
                    people[i] = new Teacher(name, (ushort)rnd.Next(30, 60), subjects[rnd.Next(subjects.Length)], 25000);
                }
            }

            //Зберігаємо у файл
            using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                for (int i = 0; i < people.Length; i++)
                {
                    people[i].SaveToFile(writer);
                }
            }
            Console.WriteLine("Дані збережено у файл!\n");

            //Читаємо з файлу
            List loadedPeople = new List();

            using (StreamReader reader = new StreamReader(fileName, Encoding.UTF8))
            {
                while (!reader.EndOfStream)
                {
                    string type = reader.ReadLine()!;

                    Person p = null!;

                    if (type == "Student")
                        p = new Student();
                    else
                        p = new Teacher();

                    p.ReadFromFile(reader);
                    loadedPeople.Add(p);
                }
            }

            //Виводимо зчитані дані на екран
            Console.WriteLine("Прочитано з файлу");
            for (int i = 0; i < loadedPeople.Count; i++)
            {
                Console.WriteLine();
            }
        }
    }
}
