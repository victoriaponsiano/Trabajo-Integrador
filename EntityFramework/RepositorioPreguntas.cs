using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Integrador.EntityFramework
{
    public class RepositorioPreguntas : Repository<Pregunta, TrabajoDbContext>
    {

        public RepositorioPreguntas(TrabajoDbContext pContext) : base(pContext) {
    
        }




        /// <summary>
        /// Devuelve una lista de preguntas de acuerdo a la cantidad, categoria y dificultad.
        /// </summary>
        /// <param name="pCantidad"></param>
        /// <param name="pCategoria"></param>
        /// <param name="pDificultad"></param>
        /// <returns>Una Lista de preguntas</returns>
        public List<Pregunta> GetRandom(int pCantidad,ConjuntoPreguntas pConjunto, CategoriaPregunta pCategoria, Dificultad pDificultad)
        {
            
            List<Pregunta> preguntas = iDBSet.Include("Conjunto").Include("Dificultad").Where(p => ((p.Dificultad.Id == pDificultad.Id) && (p.Categoria.Id == pCategoria.Id) && (p.Conjunto.Id == pConjunto.Id))).ToList<Pregunta>();

            if (preguntas.Count <= pCantidad)
            {
                return preguntas;
            }
            else
            {
                return preguntas.OrderBy(x => Guid.NewGuid()).Take(pCantidad).ToList<Pregunta>();
            }



        }
    }
}
