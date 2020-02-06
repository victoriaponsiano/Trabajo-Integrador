using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Integrador.EntityFramework;
using System.Web;


namespace Trabajo_Integrador
{
    class Program
    {
        static void Main(string[] args)
        {
            /*    CategoriaPregunta cat = new CategoriaPregunta("Vehicles");
                Dificultad dif = new Dificultad("easy");
                Examen ex = new Examen(10, cat, dif);

                foreach (Pregunta pre in ex.Preguntas)
                {
                    Console.WriteLine($"{pre.Id}");
                }*/

            string path = "hola";
            Bitacora oLog = new Bitacora(path);
            oLog.Add("Hola mundo");

            Console.ReadKey();
        }
    }
}
