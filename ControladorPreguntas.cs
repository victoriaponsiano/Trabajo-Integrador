using System;
using System.Collections.Generic;
using Trabajo_Integrador.EntityFramework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Integrador;

namespace Trabajo_Integrador
{
    public class ControladorPreguntas
    {
        private static ControladorPreguntas cinstancia = null;
        private IEstrategiaObtenerPreguntas iEstrategiaObtenerPreguntas;
        private List<IEstrategiaObtenerPreguntas> iEstrategias;
        public static ControladorPreguntas Instance
        //Implementacion del patron singleton
        {
            get
            {
                if (cinstancia == null)
                {
                    cinstancia = new ControladorPreguntas();
                }
                return cinstancia;
            }
        }
 




        public IEstrategiaObtenerPreguntas GetEstrategia(String nombre)
        //Devuelve la estrategia cuyo nombre sea igual al parametro,
        //Sino devuelve estrategia nula
        {
            IEstrategiaObtenerPreguntas estrategiaRetorno = new EstrategiaNula();
            foreach (EstrategiaObtenerPreguntas est in iEstrategias)
            {
                if (est.Conjunto== nombre)
                {
                    estrategiaRetorno = est;
                }
            }
            return estrategiaRetorno;
        }


        /// <summary>
        /// Dada una lista de preguntas, las inserta en la base de datos
        /// </summary>
        public void CargarPreguntas(List<Pregunta> pPreguntas)
        {

            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {

                    foreach (Pregunta pre in pPreguntas)
                    {
                        UoW.RepositorioPreguntas.Add(pre);
                    }
                    UoW.Complete();
                }

            }

        }


        /// <summary>
        /// Obtiene las preguntas de internet y devuelve una lista con preguntas
        /// </summary>
        /// <param name="pCantidad"></param>
        /// <param name="pConjunto"></param>
        /// <param name="pCategoria"></param>
        /// <param name="pDificultad"></param>
        /// <returns></returns>
        public List<Pregunta> GetPreguntas(string pCantidad,string pConjunto, string pCategoria, string pDificultad)
        {
            return iEstrategiaObtenerPreguntas.getPreguntas(pCantidad, pDificultad, pCategoria);
        }


        /// <summary>
        /// Constructor
        /// </summary>
        public ControladorPreguntas()
        {
            iEstrategias = new List<IEstrategiaObtenerPreguntas>();
            iEstrategias.Add(new OpentDB());
            iEstrategiaObtenerPreguntas = this.GetEstrategia("OpentDB");
        }
    }
}
