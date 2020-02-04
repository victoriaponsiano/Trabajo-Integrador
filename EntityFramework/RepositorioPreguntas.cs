using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Integrador;

namespace Trabajo_Integrador
{
    public class RepositorioPreguntas
    {
        private static RepositorioPreguntas cinstancia = null;
        private IEstrategiaObtenerPreguntas iEstrategiaObtenerPreguntas;
        private List<IEstrategiaObtenerPreguntas> iEstrategias;
        public static RepositorioPreguntas Instance
        //Implementacion del patron singleton
        {
            get
            {
                if (cinstancia == null)
                {
                    cinstancia = new RepositorioPreguntas();
                }
                return cinstancia;
            }
        }
        private RepositorioPreguntas()
        //Constructor
        {
            iEstrategias = new List<IEstrategiaObtenerPreguntas>();
            iEstrategias.Add(new OpentDB());
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
        public void CargarPreguntas(string pCantidad,string pCategoriaPregunta,string Dificultad)
        {

        }
        public List<Pregunta> GetPreguntas(string pCantidad,string pConjunto, string pCategoria, string pDificultad)
        {
            return iEstrategiaObtenerPreguntas.getPreguntas(pCantidad, pDificultad, pCategoria);
        }
    }
}
