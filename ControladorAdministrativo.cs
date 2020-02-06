using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Integrador.Dominio;
using Trabajo_Integrador.EntityFramework;

namespace Trabajo_Integrador
{
    /// <summary>
    /// Clase utilizada por el administrador.
    /// </summary>
    public class ControladorAdministrativo
    {
        ControladorPreguntas iControladorPreguntas = new ControladorPreguntas();
        public void CargarPreguntas(string pCantidad, string pConjunto, string pCategoria, string pDificultad)
        {
            iControladorPreguntas.GetPreguntasOnline(pCantidad, pConjunto, pCategoria, pDificultad);
        }
        public List<Usuario> GetUsuarios()
        {
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    return (List<Usuario>)UoW.RepositorioUsuarios.GetAll();
                }
            }
        }
        public List<Pregunta> GetPreguntas()
        {
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    return (List<Pregunta>)UoW.RepositorioPreguntas.GetAll();
                }
            }
        }
        public List<Examen> GetExamenes()
        {
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    return (List<Examen>)UoW.ExamenRepository.GetAll();
                }
            }
        }
        public void ModificarTiempo(int pConjuntoPreguntas, float pTiempo)
        {
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    UoW.RepositorioConjuntoPregunta.Get(pConjuntoPreguntas);
                }
            }
        }
        public List<ConjuntoPreguntas> GetConjuntos()
        {
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    return (List<ConjuntoPreguntas>)UoW.RepositorioConjuntoPregunta.GetAll();
                }
            }
        }
        public void SetAdministrador(Usuario pUsuario)
        {
            pUsuario.Aministrador = true;
        }

    }
}
