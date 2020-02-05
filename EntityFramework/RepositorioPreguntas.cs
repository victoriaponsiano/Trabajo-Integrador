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
            List<Pregunta> ADevolver = (List<Pregunta>) this.GetAll();
            
            foreach (Pregunta pre in ADevolver) 
            {
                if (!((pre.Categoria.Id == pCategoria) && (pre.Dificultad.Id == pDificultad)))
                {
                    ADevolver.Remove(pre);
                }
            }

            if (ADevolver.Count() > pCantidad)
            {
                ADevolver.RemoveRange(0, ADevolver.Count() - pCantidad);
                return ADevolver;
            }
            else
            {
                return ADevolver;
            }
           


        }
    }
}
