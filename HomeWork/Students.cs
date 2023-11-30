using HomeWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HomeWork
{
    
    internal class Students
    {
        private Dictionary<string, List<Student>> studentsByGroup = new Dictionary<string, List<Student>>();
        private List<Event> events = new List<Event>();


        public void ReadStudentsFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] studentData = line.Split(';');
                if (studentData.Length == 2)
                {
                    string name = studentData[0].Trim();
                    string group = studentData[1].Trim();

                    Student student = new Student(name, group, DateTime.Now);

                    if (!studentsByGroup.ContainsKey(group))
                    {
                        studentsByGroup[group] = new List<Student>();
                    }

                    studentsByGroup[group].Add(student);
                }
            }
        }


        public void SaveEventToFile(string fileName, Event ev)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine($"Date: {ev.Date}");
                writer.WriteLine($"Event: {ev.Name}");
                writer.WriteLine($"Participants count: {ev.ParticipantsPerGroup}");
                writer.WriteLine("Participants:");

                foreach (Student student in ev.Participants)
                {
                    writer.WriteLine($"{student.Name} ({student.Group})");
                }
            }
        }
        public void AssignStudentsToEvent(Event ev)
        {
            List<Student> eligibleStudents = GetEligibleStudents(ev);

            if (eligibleStudents.Count >= ev.ParticipantsPerGroup)
            {
                Random random = new Random();
                List<Student> selectedStudents = eligibleStudents.OrderBy(s => random.Next()).Take(ev.ParticipantsPerGroup).ToList();

                ev.Participants.AddRange(selectedStudents);

                foreach (Student student in selectedStudents)
                {
                    student.LastEvent = ev.Date;
                }

                events.Add(ev);

                Console.WriteLine($"Мероприятие '{ev.Name}' участники:");
                foreach (Student student in selectedStudents)
                {
                    Console.WriteLine($"{student.Name} ({student.Group})");
                }
            }
            else
            {
                Console.WriteLine($"Нет участник желающих'{ev.Name}'.");
            }
        }
        private List<Student> GetEligibleStudents(Event ev)
        {
            return studentsByGroup.Values
                .SelectMany(group => group)
                .Where(s => s.LastEvent < ev.Date.AddDays(-3) || s.LastEvent == DateTime.MinValue)
                .Where(s => s.WantsToParticipate())
                .ToList();
        }


    }
}
