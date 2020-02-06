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

                        if (db.Preguntas.Find(pre.Id) == null)
                        {
                            CategoriaPregunta categoria = db.Categorias.Find(pre.Categoria.Id);
                            Dificultad dificultad = db.Dificultades.Find(pre.Dificultad.Id);

                            ///Si la categoria esta en la base de datos la referencia,
                            ///sino crea una nueva y la inserta en la db
                            if (categoria == null)
                            {
                                CategoriaPregunta categoriaNueva = new CategoriaPregunta(pre.Categoria.Id);
                                Console.WriteLine($"agrego: {categoriaNueva.Id}");
                            }
                            else
                            {
                                //db.Categorias.Attach(categoria);
                                pre.Categoria = categoria;
                            }


                            ///Si la dificultad esta en la base de datos la referencia,
                            ///sino crea una nueva y la inserta en la db
                            if (dificultad == null)
                            {
                                Dificultad dificultadNueva = new Dificultad(pre.Dificultad.Id);
                            }
                            else
                            {
                                //db.Dificultades.Attach(dificultad);
                                pre.Dificultad = dificultad;
                            }



                            UoW.RepositorioPreguntas.Add(pre);
                        }
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
        public List<Pregunta> GetPreguntasOnline(string pCantidad,string pConjunto, string pCategoria, string pDificultad)
        {
           
            return iEstrategiaObtenerPreguntas.getPreguntas(pCantidad, pDificultad, pCategoria);
        }





        /// <summary>
        /// Obtiene preguntas random de la base de datos
        /// </summary>
        /// <param name="pCantidad"></param>
        /// <param name="pCategoria"></param>
        /// <param name="pDificultad"></param>
        /// <returns></returns>
        public List<Pregunta> GetPreguntasRandom(int pCantidad,ConjuntoPreguntas pConjunto, CategoriaPregunta pCategoria, Dificultad pDificultad)
        {
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                   return UoW.RepositorioPreguntas.GetRandom(pCantidad,pConjunto, pCategoria, pDificultad);
                }
            }
                
        }





        /// <summary>
        /// Implementacion del patron singleton
        /// </summary>
        public static ControladorPreguntas Instance
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
