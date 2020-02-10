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
                Bitacora.GuardarLog("ControladorAdministrativo.GetUsuarios:"+ex.ToString());
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
                Bitacora.GuardarLog("ControladorAdministrativo.GetPreguntas:"+ex.ToString());
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
                Bitacora.GuardarLog("ControladorAdministrativo.GetExamenes:"+ex.ToString());
            }
            return listaExamenes;

        }
        /// <summary>
        /// Metodo que devuelve todas las categorias cargadas en base de datos
        /// </summary>
        /// <returns></returns>
        public List<CategoriaPregunta> GetCategorias()
        {
            return iControladorPreguntas.GetCategorias();
        }

        /// <summary>
        /// Metodo que devuelve todas los conjuntos de preguntas cargados en base de datos
        /// </summary>
        /// <returns></returns>
        public List<ConjuntoPreguntas> GetConjuntoPreguntas()
        {
            return iControladorPreguntas.GetConjuntoPreguntas();
        }
        /// <summary>
        /// Metodo que devuelve todas las dificultades cargadas en base de datos
        /// </summary>
        /// <returns></returns>
        public List<Dificultad> GetDificultades()
        {
            return iControladorPreguntas.GetDificultades();
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
                Bitacora.GuardarLog("ControladorAdministrativo.ModificarTiempo: "+ex.ToString());
            }

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
            catch (NullReferenceException ex)
            {
                Bitacora.GuardarLog("ControladorAdministrativo.SetAdministrador: "+
                    ex.Message);
            }
        }
        public void GuardarUsuario(string pUsuario, string pContrasenia)
        {
            Usuario usuario = new Usuario(pUsuario, pContrasenia);
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                { 
                        UoW.RepositorioUsuarios.Add(usuario);
                        UoW.Complete();
                }
            }
        }
    }
}
