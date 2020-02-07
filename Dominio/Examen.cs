using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Integrador.Controladores;


namespace Trabajo_Integrador.Dominio
{
    public class Examen
    {
        
        ControladorPreguntas iControladorPreguntas;



        private int iRespuestasCorrectas;
        public int Id { get; set; }


        /// <summary>
        /// Tiempo limite en segundos
        /// </summary>
        public float TiempoLimite { set; get; }


        /// <summary>
        /// Devuelve el factor tiempo para utilizar en el calculo del puntaje
        /// </summary>
        private double FactorTiempo { 
            get 
            {
                double factor = TiempoUsado / getPreguntas().Count;

                if (factor < 5)
                {
                    return 5;
                }
                else if (factor < 20)
                {
                    return 3;
                }
                else return 1;
            } 
        }



        /// <summary>
        /// Devuelve el puntaje de un examen
        /// </summary>
        public double Puntaje { get; private set; }


        /// <summary>
        /// Tiempo usado en segundos
        /// </summary>
        public double TiempoUsado { set; get; }
        public DateTime Fecha { get; set; }

        public Usuario Usuario {get;set;}

        public int CantidadPreguntas { get; set; }



        private List<Pregunta> iPreguntas;


        public List<Pregunta> getPreguntas() 
        {
            if (iPreguntas != null)
            { return iPreguntas; }
            else
            {
                iPreguntas = iControladorPreguntas.ObtenerPreguntasDeExamen(this.Id);
                return iPreguntas;
            }
        }


        /// <summary>
        /// Calcula el puntaje de un examen
        /// </summary>
        /// <returns></returns>
        private double CalcularPuntaje() 
        {

            return (iRespuestasCorrectas / getPreguntas().Count) * getPreguntas().First().Dificultad.FactorDificultad * FactorTiempo;
        }




        /// <summary>
        /// Dada una pregunta y una respuesta, dice si es correcta o no y modifica el contador de respuetas correctas.
        /// </summary>
        /// <param name="pPregunta"></param>
        /// <param name="pRespuesta"></param>
        /// <returns>Verdadero si respuesta es correcta</returns>
        public Boolean RespuestaCorrecta(Pregunta pPregunta, String pRespuesta)
        {
            if (pPregunta.RespuestaEsCorrecta(pRespuesta))
            {
                iRespuestasCorrectas++;
                iControladorPreguntas.MarcarRespuesta(this.Id, pPregunta, pRespuesta);
                return true;
            }
            else
            {
                iControladorPreguntas.MarcarRespuesta(this.Id, pPregunta, pRespuesta);
                return false;

            } 
        }







        /// <summary>
        /// Da fin a un examen
        /// </summary>
        public void Finalizar()
        {
            TiempoUsado = (DateTime.Now - Fecha).TotalSeconds;
            Puntaje = CalcularPuntaje();
        }


        /// <summary>
        /// Da inicio a un examen
        /// </summary>
        public void Iniciar() 
        {
            Fecha = DateTime.Now;
        }



        /// <summary>
        /// Carga las preguntas y llena las listas de pregunta y preguntaexamen
        /// </summary>
        /// <param name="pCantidad"></param>
        /// <param name="pConjunto"></param>
        /// <param name="pCategoria"></param>
        /// <param name="pDificultad"></param>
        private void CargarPreguntas(int pCantidad, ConjuntoPreguntas pConjunto, CategoriaPregunta pCategoria, Dificultad pDificultad) 
        {
            iPreguntas = iControladorPreguntas.GetPreguntasRandom(pCantidad, pConjunto, pCategoria, pDificultad);
            iControladorPreguntas.AsociarPreguntaExamen(this.Id, iPreguntas);
        }


        /// <summary>
        /// Constructor de examen
        /// </summary>
        /// <param name="pCantidad"></param>
        /// <param name="pCategoria"></param>
        /// <param name="pDificultad"></param>
        /// 
        public Examen(int pId,int pCantidad,ConjuntoPreguntas pConjunto, CategoriaPregunta pCategoria, Dificultad pDificultad)
        {
            this.iRespuestasCorrectas = 0;
            this.Id = pId;
            this.CantidadPreguntas = pCantidad;
            this.iControladorPreguntas = new ControladorPreguntas();
            CargarPreguntas(pCantidad, pConjunto, pCategoria, pDificultad);
        }

        public Examen() { }
    }
}
