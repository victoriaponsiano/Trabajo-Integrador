using System;
using System.Collections.Generic;
using Trabajo_Integrador.EntityFramework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Integrador;
using Trabajo_Integrador.Dominio;

namespace Trabajo_Integrador.Controladores
{
    public class ControladorPreguntas
    {

        /// <summary>
        /// atributos
        /// </summary>
        private static ControladorPreguntas cinstancia = null;
        private IEstrategiaObtenerPreguntas iEstrategiaObtenerPreguntas;
        private List<IEstrategiaObtenerPreguntas> iEstrategias;

        /// <summary>
        /// Obtiene la estrategia a utilizar teniendo como parametro el conjunto de preguntas
        /// Si no encuentra la estrategia devuelve la nula
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public IEstrategiaObtenerPreguntas GetEstrategia(String nombre)
        {
            IEstrategiaObtenerPreguntas estrategiaRetorno = new EstrategiaNula();
            foreach (EstrategiaObtenerPreguntas est in iEstrategias)
            {
                if (est.Conjunto == nombre)
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
            try
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
                                ConjuntoPreguntas conjunto = db.ConjuntoPreguntas.Find(pre.Conjunto.Id);

                                ///Si la categoria esta en la base de datos la referencia,
                                ///sino crea una nueva y la inserta en la db
                                if (categoria == null)
                                {
                                    CategoriaPregunta categoriaNueva = new CategoriaPregunta(pre.Categoria.Id);
                                }
                                else
                                {
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
                                    pre.Dificultad = dificultad;
                                }

                                ///Si el conjunto esta en la base de datos la referencia,
                                ///sino crea uno nuevo y la inserta en la db
                                if (conjunto == null)
                                {
                                    ConjuntoPreguntas conjuntoNuevo = new ConjuntoPreguntas(pre.Conjunto.Id);
                                }
                                else
                                {
                                    pre.Conjunto = conjunto;
                                }


                                UoW.RepositorioPreguntas.Add(pre);
                            }
                        }
                        UoW.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                Bitacora.GuardarLog(ex.Message.ToString());
            }
        }
     


        /// <summary>
        /// Obtiene las preguntas de internet y se cargan en la base de datos.
        /// </summary>
        /// <param name="pCantidad"></param>
        /// <param name="pConjunto"></param>
        /// <param name="pCategoria"></param>
        /// <param name="pDificultad"></param>
        /// <returns></returns>
        public void GetPreguntasOnline(string pCantidad,string pConjunto, string pCategoria, string pDificultad)
        {
            try
            {
                IEstrategiaObtenerPreguntas estrategia = this.GetEstrategia(pConjunto);
                List<Pregunta> preguntas = estrategia.getPreguntas(pCantidad, pConjunto, pDificultad, pCategoria);
                CargarPreguntas(preguntas);
            }
            catch (Exception ex)
            {
                Bitacora.GuardarLog(ex.Message.ToString());
            }
        }






        /// <summary>
        /// Marca una respuesta en la base de datos como verdadera o falsa.
        /// </summary>
        /// <param name="pExamenId"></param>
        /// <param name="pPregunta"></param>
        /// <param name="pRespuesta"></param>
        /// <param name="pEsCorrecto"></param>
        public void MarcarRespuesta(int pExamenId, Pregunta pPregunta, String pRespuesta)
        {
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    ExamenPregunta preex = UoW.RepositorioPreguntasExamenes.Get(pExamenId, pPregunta.Id);
                    preex.OpcionElegida = pRespuesta;
                    UoW.Complete();
                }
            }
        }


        /// <summary>
        /// Crea la asociacion en la base de datos de preguntaexamen
        /// </summary>
        /// <param name="ExamenId"></param>
        /// <param name="Preguntas"></param>
        public void AsociarPreguntaExamen(int pExamenId,ICollection<Pregunta> pPreguntas) 
        {
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    foreach (Pregunta pre in pPreguntas) 
                    {
                        ExamenPregunta preguntaExamen = new ExamenPregunta();
                        preguntaExamen.ExamenId = pExamenId;
                        preguntaExamen.PreguntaId = pre.Id;
                        UoW.RepositorioPreguntasExamenes.Add(preguntaExamen);
                    }
                    UoW.Complete();
                }
            }
               
        }

        /// <summary>
        /// Obtiene las preguntas asociadas a un examen
        /// </summary>
        /// <returns></returns>
        public List<Pregunta> ObtenerPreguntasDeExamen(int pExamenId) 
        {
            List<Pregunta> preguntas = new List<Pregunta>();
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    //Primero busca los objetos de la clase de asociacion preguntaexamen
                    List<ExamenPregunta> preguntaExamenes = db.PreguntasExamenes.Where(c => c.ExamenId == pExamenId).ToList<ExamenPregunta>();
                    
                    //Luego con los preguntaExamen obtiene las preguntas de un examen
                    foreach (ExamenPregunta pe in preguntaExamenes) 
                    {
                        preguntas.Add(UoW.RepositorioPreguntas.Get(pe.PreguntaId));
                    }
                }
            }
            return preguntas;

        }



        /// <summary>
        /// Obtiene preguntas random de la base de datos
        /// </summary>
        /// <param name="pCantidad"></param>
        /// <param name="pConjunto"></param>
        /// <param name="pCategoria"></param>
        /// <param name="pDificultad"></param>
        /// <returns></returns>
        public List<Pregunta> GetPreguntasRandom(int pCantidad,ConjuntoPreguntas pConjunto, CategoriaPregunta pCategoria, Dificultad pDificultad)
        {
            List<Pregunta> preguntas = new List<Pregunta>();
            try
            {
                using (var db = new TrabajoDbContext())
                {
                    using (var UoW = new UnitOfWork(db))
                    {
                        preguntas = (List<Pregunta>)UoW.RepositorioPreguntas.GetRandom(pCantidad, pConjunto, pCategoria, pDificultad);
                    }
                }
            }
            catch (Exception ex)
            {
                Bitacora.GuardarLog(ex.Message.ToString());
            }
            return preguntas;
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
