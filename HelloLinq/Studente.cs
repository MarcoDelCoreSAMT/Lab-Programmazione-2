using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloLinq
{
    internal class Studente
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Branch { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }
        public string Subject { get; set; }
        public List<string> Programming { get; set; }

        public static List<Studente> GetStudents()
        {
            return new List<Studente>()
            {
                new Studente { ID = 1001, Name = "Marco", Gender = "Male", Branch = "Informatica", Age = 20, Grade = 85, Subject = "Matematica", Programming = new List<string> { "C#", "Java" } },
                new Studente { ID = 1002, Name = "Vittoria", Gender = "Female", Branch = "Telecomunicazioni", Age = 21, Grade = 90, Subject = "Italiano", Programming = new List<string> { "SQL", "C#" } },
                new Studente { ID = 1003, Name = "Fabio", Gender = "Male", Branch = "Informatica", Age = 21, Grade = 80, Subject = "Matematica", Programming = new List<string> { "C#", "C++" } },
                new Studente { ID = 1004, Name = "Carla", Gender = "Female", Branch = "Telecomunicazioni", Age = 20, Grade = 65, Subject = "Scienze", Programming = new List<string> { "Python" } },
                new Studente { ID = 1005, Name = "Andrea", Gender = "Male", Branch = "Telecomunicazioni", Age = 21, Grade = 72, Subject = "Italiano", Programming = new List<string> { "Java", "SQL" } },
                new Studente { ID = 1006, Name = "Sara", Gender = "Female", Branch = "Informatica", Age = 21, Grade = 95, Subject = "Matematica", Programming = new List<string> { "LINQ", "C#" } },
                new Studente { ID = 1007, Name = "Guido", Gender = "Male", Branch = "Informatica", Age = 22, Grade = 60, Subject = "Scienze", Programming = new List<string> { "C++" } },
                new Studente { ID = 1008, Name = "Sergio", Gender = "Male", Branch = "Informatica", Age = 20, Grade = 78, Subject = "Italiano", Programming = new List<string> { "C#", "Python" } },
                new Studente { ID = 1009, Name = "Giorgia", Gender = "Female", Branch = "Telecomunicazioni", Age = 22, Grade = 45, Subject = "Matematica", Programming = new List<string> { "Java" } },
                new Studente { ID = 1010, Name = "Matteo", Gender = "Male", Branch = "Informatica", Age = 21, Grade = 100, Subject = "Scienze", Programming = new List<string> { "C#", "Java", "SQL" } }
            };
        }
    }
}
