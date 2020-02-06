using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Integrador
{
    /// <summary>
    /// Clase que representa la dificultad de cada pregunta
    /// </summary>
    public class Dificultad
    {
        /// <summary>
        /// Atributos
        /// </summary>
        string iDificultad;

        /// <summary>
        /// Properties
        /// </summary>
        public string Id
        {
            get { return iDificultad; }
            set { iDificultad = value; }
        }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pDificultad"></param>
        public Dificultad(string pDificultad)

        {
            Id = pDificultad;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        public Dificultad()
        { }
    }
}
