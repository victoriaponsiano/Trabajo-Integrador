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

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public ConjuntoPreguntas(string pDescripcion, float pTiempoEsperadoRespuesta)
        {
            Descripcion= pDescripcion;
            iTiempoEsperadoRespuesta = pTiempoEsperadoRespuesta;
        }
        public ConjuntoPreguntas(string pDescripcion)
        {
            Descripcion = pDescripcion;
            iTiempoEsperadoRespuesta = 20;
        }

        public ConjuntoPreguntas() { }

    }
}
