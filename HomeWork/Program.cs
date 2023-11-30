using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задач 1: Необходимо создать программу, которая будет из текстового файла считывать всех студентов\r\n" +
                "и их принадлежность к группе. Далее пользователь создает мероприятие с необходимым\r\n" +
                "количеством участников, оно записывается в специально созданный файл. Далее дозаписать\r\n" +
                "в файл с мероприятием всех участников мероприятия.");
            Students students = new Students();

            CreateStudentFile("Group1.txt", "Group1", 15);
            CreateStudentFile("Group2.txt", "Group2", 20);
            CreateStudentFile("Group3.txt", "Group3", 10);
            students.ReadStudentsFromFile("Group1.txt");
            students.ReadStudentsFromFile("Group2.txt");
            students.ReadStudentsFromFile("Group3.txt");

            Event event1 = new Event("Театр", new DateTime(2023, 12, 11), 5);
            Event event2 = new Event("Концерт", new DateTime(2023, 12, 15), 8);

            students.AssignStudentsToEvent(event1);
            students.AssignStudentsToEvent(event2);
            students.SaveEventToFile("Event1.txt", event1);
            students.SaveEventToFile("Event2.txt", event2);

            Console.WriteLine("Нажмите Enter");
            Console.ReadKey();

            Console.WriteLine("Написать программу для слежения за интересующим вас событием\r\n" +
                "(выход сериала, концерт и т.д.)\r\n" +
                "Создать не менее трех человек с разными увлечениями. Пользователь вводит (можно из\r\n" +
                "заранее определенного списка) событие. Если событие совпало с увлечением кого-либо,\r\n" +
                "вывести его реакцию на событие.");
            Console.WriteLine("Варианты: Кино, Музыка, Спорт");
            Person person1 = new Person("Иван", "Кино");
            Person person2 = new Person("Мария", "Музыка");
            Person person3 = new Person("Петр", "Спорт");
            string ev = Console.ReadLine();
            foreach (Person person in new[] { person1, person2, person3})
            {
                string reaction = person.GetReactionToEvent(ev);
                Console.WriteLine(person.Name + ": " + reaction);
            }
            Console.WriteLine("Нажмите Enter");
            Console.ReadKey();
        }
        static void CreateStudentFile(string fileName, string groupName, int numberOfStudents)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {

                for (int i = 1; i <= numberOfStudents; i++)
                {
                    string studentName = $"Student{i}";
                    writer.WriteLine($"{studentName}; {groupName}");
                }
            }
        }
    }
}
