using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Integrador.EntityFramework;
using Trabajo_Integrador.Dominio;

namespace Trabajo_Integrador
{
    public class ControladorExamen
    {



        /// <summary>
        /// Crea un nuevo examen no asociado a un usuario
        /// </summary>
        /// <param name="pCantidad"></param>
        /// <param name="pConjunto"></param>
        /// <param name="pCategoria"></param>
        /// <param name="pDificultad"></param>
        public Examen InicializarExamen(int pCantidad, String pConjunto, string pCategoria, string pDificultad)
        {
            Dificultad dif = new Dificultad(pDificultad);
            CategoriaPregunta cat = new CategoriaPregunta(pCategoria);
            ConjuntoPreguntas conj = new ConjuntoPreguntas(pConjunto);
            return new Examen(pCantidad, conj, cat, dif);

        }







        /// <summary>
        /// Dado un examen, una pregunta y una respuesta, devuelve verdadero si la respuesta es correcta.
        /// </summary>
        /// <param name="pExamen"></param>
        /// <param name="pPregunta"></param>
        /// <param name="pRespuesta"></param>
        /// <returns></returns>
        public Boolean RespuestaCorrecta(Examen pExamen, Pregunta pPregunta, String pRespuesta)
        {
            return pExamen.RespuestaCorrecta(pPregunta, pRespuesta);

        }



        /// <summary>
        /// Da fin a un examen y lo guarda en la DB
        /// </summary>
        /// <param name="pExamen"></param>
        public void FinalizarExamen(Examen pExamen)
        {
            pExamen.Finalizar();
            GuardarExamen(pExamen);
        }




        /// <summary>
        /// Da comienzo a un examen
        /// </summary>
        /// <param name="pUsuario"></param>
        /// <param name="pExamen"></param>
        public void IniciarExamen(Usuario pUsuario, Examen pExamen)
        {
            pExamen.Usuario = pUsuario;
            pExamen.Iniciar();
        }


        /// <summary>
        /// Guarda un examen la base de datos
        /// </summary>
        /// <param name="pExamen"></param>
        public void GuardarExamen(Examen pExamen) 
        {
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    UoW.ExamenRepository.Add(pExamen);
                }
            }



        }

        public ControladorExamen() 
        {
        }
    }
}
