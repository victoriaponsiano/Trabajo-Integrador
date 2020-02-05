using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Integrador.Dominio;

namespace Trabajo_Integrador
{
    public class Examen
    {
        Usuario iUsuario;
        List<Pregunta> iPreguntas;
        ControladorPreguntas iControladorPreguntas;
        


        public int Id { get; set; }
        public int Puntaje { set; get; }

        public float TiempoLimite { set; get; }
        public float TiempoUsado { set; get; }
        public DateTime Fecha { get; set; }

        public int CantidadPreguntas { get; set; }
        public CategoriaPregunta CategoriaPregunta{ get; set; }
        public Dificultad Dificultad { get; set; }



        /// <summary>
        /// Constructor de examen
        /// </summary>
        /// <param name="pCantidad"></param>
        /// <param name="pCategoria"></param>
        /// <param name="pDificultad"></param>
        /// 
        public Examen(int pCantidad, CategoriaPregunta pCategoria, Dificultad pDificultad)
        {
            this.CantidadPreguntas = pCantidad;
            this.CategoriaPregunta = pCategoria;
            this.Dificultad = pDificultad;
            this.iControladorPreguntas = new ControladorPreguntas();

            iPreguntas = iControladorPreguntas.GetPreguntas(pCantidad, pCategoria.Id, pDificultad.Id);
        }

        public Examen() { }
    }
}
