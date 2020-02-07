using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Integrador.EntityFramework;
using Trabajo_Integrador.Dominio;

namespace Trabajo_Integrador.Controladores
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
        public Examen InicializarExamen(int pCantidad, string pConjunto, string pCategoria, string pDificultad)
        {
            int id;
            Dificultad dif = new Dificultad(pDificultad);
            CategoriaPregunta cat = new CategoriaPregunta();
            cat.OpentDbId =  int.Parse(pCategoria);
            ConjuntoPreguntas conj = new ConjuntoPreguntas(pConjunto);
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    
                    id = db.Examenes.Count()+1;
                }
            }

            return new Examen(id,pCantidad, conj, cat, dif);
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
                    Usuario usr = UoW.RepositorioUsuarios.Get(pExamen.Usuario.Id);
                    if (usr == null)
                    {
                        UoW.ExamenRepository.Add(pExamen);
                    }
                    else
                    {
                        pExamen.Usuario = usr;
                        UoW.ExamenRepository.Add(pExamen);

                    }

                    UoW.Complete();       
                }
            }
        }

        public ControladorExamen() 
        {
        }
    }
}
