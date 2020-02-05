using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Integrador.Dominio;

namespace Trabajo_Integrador
{
    public class Pregunta
    {
        string iRespuestaCorrecta;
        List<string> iRespuestasIncorrectas;
        Dificultad iDificultad;
        CategoriaPregunta iCategoria;

        public string Id
        { get; set; }
        public Pregunta(string pPregunta, string pRespuestaCorrecta,List<string> pRespuestasIncorrectas,Dificultad pDificultad,CategoriaPregunta pCategoria)
        {
            Id = pPregunta;
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
