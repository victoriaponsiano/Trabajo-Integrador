using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Integrador.Dominio;




namespace Examen_Virtual
{
    class ControladorFachada
    {
        ControladorExamen ctrlExamen = new ControladorExamen();
        ControladorAdministrativo ctrlAdministrativo = new ControladorAdministrativo();
        public float getTiempoLimite(Examen unExamen)
        {
            float limite = unExamen.TiempoLimite;
            return limite;
        }

        public Examen InicializarExamen(int pCantidad, String pConjunto, string pCategoria, string pDificultad)
        {

            Examen unExamen = ctrlExamen.InicializarExamen(pCantidad, pConjunto, pCategoria, pDificultad);
            return unExamen;

        }

        public void FinalizarExamen(Examen pExamen)
        {
            ctrlExamen.FinalizarExamen(pExamen);
        }

        public List<Usuario> GetUsuarios()
        {
            return (ctrlAdministrativo.GetUsuarios());
        }

        public void guardarUsuario(string usuarioNombre, string contrasenia)
        {
            ctrlAdministrativo.GuardarUsuario(string usuarioNombre, string contrasenia);
        }



    }
}
