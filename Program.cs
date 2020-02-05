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
            Console.WriteLine("Hola mundo");
            ControladorPreguntas contrPreg = new ControladorPreguntas();
            List<Pregunta> preguntas =  contrPreg.GetPreguntas("10", "OpentDB", "0", "0");
            Console.WriteLine("Pase");
            foreach(Pregunta preg in preguntas)
            {
                Console.WriteLine(preg.Id);
            }
            contrPreg.CargarPreguntas(preguntas);

        }
    }
}
