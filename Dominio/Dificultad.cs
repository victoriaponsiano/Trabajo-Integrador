using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Integrador
{
    public class Dificultad
    {

        string iDificultad;


        public string Id
        {
            get { return iDificultad; }
            set { iDificultad = value; }
        }



        public Dificultad(string pDificultad)

        {
            Id = pDificultad;
        }
        public Dificultad()
        { }
    }
}
