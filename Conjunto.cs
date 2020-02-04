using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Integrador
{
    class Conjunto
    {
        string iDescripcion;
        float iTiempoEsperadoRespuesta;

        public Conjunto(string pDescripcion, float pTiempoEsperadoRespuesta)
        {
            iDescripcion = pDescripcion;
            iTiempoEsperadoRespuesta = pTiempoEsperadoRespuesta;
        }
        public Conjunto(string pDescripcion)
        {
            iDescripcion = pDescripcion;
            iTiempoEsperadoRespuesta = 20;
        }
        
    }
}
