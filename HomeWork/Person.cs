using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    internal class Person
    {
        public string Name { get; set; }
        public string Hobby { get; set; }

        public Person(string name, string hobby)
        {
            this.Name = name;
            this.Hobby = hobby;
        }

        public string GetReactionToEvent(string ev)
        {
            if (this.Hobby == ev)
            {
                return "О, я так давно ждал этого события!";
            }
            else
            {
                return "Это событие меня не интересует.";
            }
        }
    }
}
