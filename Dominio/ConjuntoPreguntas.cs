using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Integrador
{
    public class ConjuntoPreguntas
    {
        float iTiempoEsperadoRespuesta;

        public string Id { get; set; }
        public ConjuntoPreguntas(string pDescripcion, float pTiempoEsperadoRespuesta)
        {
            Id = pDescripcion;
            iTiempoEsperadoRespuesta = pTiempoEsperadoRespuesta;
        }
        public ConjuntoPreguntas(string pDescripcion)
        {
            Id = pDescripcion;
            iTiempoEsperadoRespuesta = 20;
        }
        
    }
}
