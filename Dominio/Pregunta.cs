using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Integrador
{
    public class Pregunta
    {
        string iPregunta, iRespuestaCorrecta;
        List<string> iRespuestasIncorrectas;
        Dificultad iDificultad;
        Categoria iCategoria;
        public Pregunta(string pPregunta, string pRespuestaCorrecta,List<string> pRespuestasIncorrectas,Dificultad pDificultad,Categoria pCategoria)
        {
            iPregunta = pPregunta;
            iRespuestaCorrecta = pRespuestaCorrecta;
            iRespuestasIncorrectas = pRespuestasIncorrectas;
            iDificultad = pDificultad;
            iCategoria = pCategoria;
        }
        public Boolean RespuestaCorrecta(string respuesta)
        {
            if (respuesta == iRespuestaCorrecta)
            {
                return true;
            }
            else return false;
        }
    }
}
