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

            ControladorPreguntas contrPreg = new ControladorPreguntas();
            List<Pregunta> preguntas =  contrPreg.GetPreguntasOnline("100", "OpentDB", "0", "0");
            foreach(Pregunta pre in preguntas)
            {
                Console.WriteLine(pre.Id);
            }
            contrPreg.CargarPreguntas(preguntas);
            Console.WriteLine("termine");
            Console.ReadLine();
                    
        }
    }
}
