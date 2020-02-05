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
        public List<Pregunta> GetRandom(int pCantidad,string pCategoria,string pDificultad) 
        {


            return this.iDBSet.OrderBy(r => Guid.NewGuid()).Take(pCantidad).ToList<Pregunta>();


        }
    }
}
