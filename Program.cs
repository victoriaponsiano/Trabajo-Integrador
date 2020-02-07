using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Integrador.EntityFramework;
using Trabajo_Integrador.Dominio;
using Trabajo_Integrador.Controladores;
using System.Web;


namespace Trabajo_Integrador
{
    class Program
    {
        static void Main(string[] args)
        {
           

               
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
          

            }
            }
}
