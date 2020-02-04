using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Integrador
{
    /// <summary>
    /// Interface que especifica los metodos para poder obtener preguntas 
    /// </summary>
    interface IEstrategiaObtenerPreguntas
    {
        List<Pregunta> getPreguntas(int pCantidad, Dificultad pDificultad, Categoria pCategoria);
    }
}