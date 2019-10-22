using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutoringService
{
    class Student
    {
        public string Clazz { get; set; }
        public string Firstname { get; set; }
        public string ImagePath { get => $"Images\\{Lastname}_{Firstname}.jpg"; }
        public string Lastname { get; set; }
        public string Name { get => $"{Lastname} {Firstname}"; }
        public List<Service> Services { get; set; }                       

        public Student()
        {
            Services = new List<Service>();
        }
        public static Student Parse(string line)
        {
            string[] parts = line.Split(';');
            string[] name_parts = parts[1].Split(' ');
            return new Student{ Clazz = parts[0], Firstname = name_parts[0], Lastname = name_parts[1] };            
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
