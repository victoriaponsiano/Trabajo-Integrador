using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Integrador.EntityFramework;

namespace Trabajo_Integrador
{
    class Program
    {
        static void Main(string[] args)
        {
            Examen iExamen = new Examen();
            iExamen.Puntaje = 100;
            iExamen.Id = 1;

            TrabajoDbContext context = new TrabajoDbContext();
            ExamenRepository repoExamen = new ExamenRepository(context);


            //repoExamen.Add(iExamen);
            Examen ex2 = repoExamen.Get(1);
            Console.WriteLine($"Id: {ex2.Id}");


        }
    }
}
