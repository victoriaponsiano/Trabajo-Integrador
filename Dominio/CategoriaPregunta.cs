using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Integrador
{
    public class CategoriaPregunta
    {

        public string Id { get { return iCategoria; }
            set { iCategoria = value; }
        }
        public string iCategoria { get; set; }

        public CategoriaPregunta(string pCategoria)
        {
            iCategoria = pCategoria;
        }
        public CategoriaPregunta()
        { }
    }
}
