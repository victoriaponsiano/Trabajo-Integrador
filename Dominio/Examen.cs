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



        ControladorPreguntas iControladorPreguntas;


        public int iRespuestasCorrectas;


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
                double factor = TiempoUsado / Preguntas.Count;

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

        public List<Pregunta> Preguntas { get; set; }





        /// <summary>
        /// Calcula el puntaje de un examen
        /// </summary>
        /// <returns></returns>
        private double CalcularPuntaje() 
        {
            
            return (iRespuestasCorrectas / Preguntas.Count) * Preguntas.First().Dificultad.FactorDificultad * FactorTiempo;
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
                return true;
            }
            else return false;
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

            iRespuestasCorrectas = 0;
            Fecha = DateTime.Now;
        }



        /// <summary>
        /// Constructor de examen
        /// </summary>
        /// <param name="pCantidad"></param>
        /// <param name="pCategoria"></param>
        /// <param name="pDificultad"></param>
        /// 
        public Examen(int pCantidad,ConjuntoPreguntas pConjunto, CategoriaPregunta pCategoria, Dificultad pDificultad)
        {
            this.CantidadPreguntas = pCantidad;
            this.iControladorPreguntas = new ControladorPreguntas();
            Preguntas = iControladorPreguntas.GetPreguntasRandom(pCantidad, pConjunto, pCategoria, pDificultad);

        }

        public Examen() { }
    }
}
