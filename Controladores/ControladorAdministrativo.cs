using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Integrador.Dominio;
using Trabajo_Integrador.EntityFramework;

namespace Trabajo_Integrador.Controladores
{
    /// <summary>
    /// Clase utilizada por el administrador.
    /// </summary>
    public class ControladorAdministrativo
    {
        ControladorPreguntas iControladorPreguntas = new ControladorPreguntas();
        public void CargarPreguntas(string pCantidad, string pConjunto, string pCategoria, string pDificultad)
        {
            try
            {
                iControladorPreguntas.GetPreguntasOnline(pCantidad, pConjunto, pCategoria, pDificultad);
            }
            catch (Exception ex)
            {
                Bitacora.GuardarLog(ex.Message.ToString());
            }

        }
        public List<Usuario> GetUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            try
            {
                using (var db = new TrabajoDbContext())
                {
                    using (var UoW = new UnitOfWork(db))
                    {
                        listaUsuarios = (List<Usuario>)UoW.RepositorioUsuarios.GetAll();
                    }
                }
            }
            catch (Exception ex)
            {
                Bitacora.GuardarLog(ex.Message.ToString());
            }
            return listaUsuarios;
        }
        public List<Pregunta> GetPreguntas()
        {
            List<Pregunta> listaPreguntas = new List<Pregunta>();
            try
            {
                using (var db = new TrabajoDbContext())
                {
                    using (var UoW = new UnitOfWork(db))
                    {
                        listaPreguntas = (List<Pregunta>)UoW.RepositorioPreguntas.GetAll();
                    }
                }
            }
            catch (Exception ex)
            {
                Bitacora.GuardarLog(ex.Message.ToString());
            }
            return listaPreguntas;
        }
        public List<Examen> GetExamenes()
        {
            List<Examen> listaExamenes = new List<Examen>();
            try
            {
                using (var db = new TrabajoDbContext())
                {
                    using (var UoW = new UnitOfWork(db))
                    {
                        listaExamenes = (List<Examen>)UoW.ExamenRepository.GetAll();
                    }
                }
            }
            catch (Exception ex)
            {
                Bitacora.GuardarLog(ex.Message.ToString());
            }
            return listaExamenes;

        }
        public void ModificarTiempo(ConjuntoPreguntas pConjuntoPreguntas, float pTiempo)
        {
            try
            {
                using (var db = new TrabajoDbContext())
                {
                    using (var UoW = new UnitOfWork(db))
                    {
                        ConjuntoPreguntas conjunto=UoW.RepositorioConjuntoPregunta.Get(pConjuntoPreguntas.Id);
                        conjunto.Id = pConjuntoPreguntas.Id;
                        UoW.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                Bitacora.GuardarLog(ex.Message.ToString());
            }

        }
        public List<ConjuntoPreguntas> GetConjuntos()
        {
            List<ConjuntoPreguntas> listaConjuntos = new List<ConjuntoPreguntas>();
            try
            {
                using (var db = new TrabajoDbContext())
                {
                    using (var UoW = new UnitOfWork(db))
                    {
                        listaConjuntos = (List<ConjuntoPreguntas>)UoW.RepositorioConjuntoPregunta.GetAll();
                    }
                }
            }
            catch (Exception ex)
            {
                Bitacora.GuardarLog(ex.Message.ToString());
            }
            return listaConjuntos;

        }
        public void SetAdministrador(Usuario pUsuario)
        {
            try
            {
                using (var db = new TrabajoDbContext())
                {
                    using (var UoW = new UnitOfWork(db))
                    {
                        Usuario dBUsuario = UoW.RepositorioUsuarios.Get(pUsuario.Id);
                        dBUsuario.Administrador = true;
                        UoW.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                Bitacora.GuardarLog(ex.Message.ToString());
            }
        }
    }
}
