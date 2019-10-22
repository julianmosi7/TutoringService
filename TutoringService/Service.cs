using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutoringService
{
    class Service
    {
        public int Level { get; set; }
        public static int[] Levels { get; }
        public string Subject { get; set; }
        public static List<string> Subjects { get; }

        static Service() {
            Levels = new int[] { 1, 2, 3, 4, 5 };
            string[] lines = File.ReadAllLines("subjects.csv");
            Subjects = lines[0].Split(';').ToList();
        }
        public override string ToString()
        {            
            return $"{Subject} in {Level}.Klassen";
        }      

    }
}
