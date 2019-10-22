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
        public int[] Levels { get; }
        public string Subject { get; set; }
        public List<string> Subjects { get; }

        static Service() { }
        public string ToString(){            
            return $"{Subject} in {Level}.Klassen";
        }

        static 

        public static Service Parse(string part)
        {
            return new Service { Subject = part };
        }
    }
}
