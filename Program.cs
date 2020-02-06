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

            ControladorPreguntas contrPreg = new ControladorPreguntas();
            contrPreg.GetPreguntasOnline("100", "OpentDB", "0", "0");
            Console.WriteLine("termine");
            Console.ReadLine();
            /*  CategoriaPregunta cat = new CategoriaPregunta("Vehicles");
                Dificultad dif = new Dificultad("easy");
                Examen ex = new Examen(10, cat, dif);

                foreach (Pregunta pre in ex.Preguntas)
                {
                    Console.WriteLine($"{pre.Id}");
                }

            /*
            string path = "hola";
            Bitacora oLog = new Bitacora(path);
            oLog.Add("Hola mundo");
            */
            Console.ReadKey();
        }
    }
}
