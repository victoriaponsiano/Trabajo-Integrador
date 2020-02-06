using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Integrador
{
    /// <summary>
    /// Clase que indica de donde se obtienen las preguntas.
    /// </summary>
    public class ConjuntoPreguntas
    {
        /// <summary>
        /// atributos
        /// </summary>
        float TiempoEsperadoRespuesta { get; set; }

        /// <summary>
        /// Properties.
        /// </summary>
        public int Id { get; set; }
        public string Descripcion { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pDescripcion"></param>
        /// <param name="pTiempoEsperadoRespuesta"></param>
        public ConjuntoPreguntas(string pDescripcion, float pTiempoEsperadoRespuesta)
        {
            Descripcion= pDescripcion;
            TiempoEsperadoRespuesta = pTiempoEsperadoRespuesta;
        }
        /// <summary>
        /// construtor
        /// </summary>
        /// <param name="pDescripcion"></param>
        public ConjuntoPreguntas(string pDescripcion)
        {
            Descripcion = pDescripcion;
            TiempoEsperadoRespuesta = 20;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        public ConjuntoPreguntas() { }

    }
}
