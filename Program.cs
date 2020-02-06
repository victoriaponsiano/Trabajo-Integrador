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
            Usuario leo = new Usuario("40806563", "leonardo");
            Examen ex = new Examen(10, new ConjuntoPreguntas("OpentDB"), new CategoriaPregunta("9"), new Dificultad("easy"));
            ex.Iniciar();
            ex.Finalizar();
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    UoW.ExamenRepository.Add(ex);
                    UoW.Complete();
                }
            }

                    /*
                    ControladorExamen cont = new ControladorExamen();


                    Examen ex = cont.InicializarExamen(10, "OpentDB","9","easy");
                    cont.IniciarExamen(leo, ex);

                    foreach (Pregunta pre in ex.Preguntas) 
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
