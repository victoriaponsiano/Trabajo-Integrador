using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Integrador.EntityFramework;
using Trabajo_Integrador.Dominio;
using System.Web;


namespace Trabajo_Integrador
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var db = new TrabajoDbContext())
            {
                Console.WriteLine(db.Examenes.Count<Examen>());
            }

                /*
                Usuario leo = new Usuario("40806563", "leonardo");


                        ControladorExamen cont = new ControladorExamen();


                        Examen ex = cont.InicializarExamen(10, "OpentDB","9","easy");
                        cont.IniciarExamen(leo, ex);

                        foreach (Pregunta pre in ex.getPreguntas()) 
                        {
                            Console.WriteLine($"{pre.Id}");
                            cont.RespuestaCorrecta(ex, pre, pre.RespuestaCorrecta);

                        }
                        Console.ReadLine();
                        cont.FinalizarExamen(ex);


                    Console.ReadKey();
            */

            }
            }
}
