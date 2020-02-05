using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Integrador.Dominio
{
    public class Usuario
    {
        public String Id { get; set; }
        public String Contrasenia { get; set; }
        public Boolean Aministrador { get; set; }
        
        public Usuario(string pId, string pContrasenia)
        {
            Id = pId;
            Contrasenia = pContrasenia;
            Aministrador = false;
        }
    }
}
