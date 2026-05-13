using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Studente> students = Studente.GetStudents();

            Console.WriteLine("============ Hello LINQ! ============");
            Console.WriteLine("-----------\nEsercizio 1: trova tutti gli studenti con voto maggiore o uguale a 70.\n-----------");

            var es1 = students.Where(s => s.Grade >= 70).Select(s => s.Name).ToList();

            foreach (var x1 in es1)
            {
                Console.WriteLine(x1);
            }

            Console.WriteLine("\n-----------\nEsercizio 2: recupera solo i nomi degli studenti del branch 'Informatica'.\n-----------");

            var es2 = students.Where(s => s.Branch == "Informatica").Select(s => s.Name).ToList();

            foreach (var x2 in es2)
            {
                Console.WriteLine(x2);
            }

            Console.WriteLine("\n-----------\nEsercizio 3: verifica se esiste almeno uno studente con voto pari a 100.\n-----------");
            var es3 = students.Any(s => s.Grade == 100).ToString();
            
            Console.WriteLine(es3);

            Console.WriteLine("\n-----------\nEsercizio 4: verifica se tutti gli studenti hanno voto maggiore di 40.\n-----------");
            var es4 = students.All(s => s.Grade > 40).ToString();
            
            Console.WriteLine(es4);

            Console.WriteLine("\n-----------\nEsercizio 5: recupera il primo studente del branch Telecomunicazioni usando FirstOrDefault().\n-----------");
            var es5 = students.FirstOrDefault(s => s.Branch == "Telecomunicazioni");

            Console.WriteLine(es5);
        }
    }
}
