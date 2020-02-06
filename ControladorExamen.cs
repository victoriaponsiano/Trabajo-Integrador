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

        private Examen iExamen;



        /// <summary>
        /// Crea un nuevo examen no asociado a un usuario
        /// </summary>
        /// <param name="pCantidad"></param>
        /// <param name="pConjunto"></param>
        /// <param name="pCategoria"></param>
        /// <param name="pDificultad"></param>
        public Examen InicializarExamen(int pCantidad,String pConjunto,string pCategoria, string pDificultad) 
        {
            Dificultad dif = new Dificultad(pDificultad);
            CategoriaPregunta cat = new CategoriaPregunta(pCategoria);
            ConjuntoPreguntas conj = new ConjuntoPreguntas(pConjunto);
            return new Examen(pCantidad,conj,cat, dif);
            
        }


        public void IniciarExamen(Usuario pUsuario, Examen pExamen)
        { 
            
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
