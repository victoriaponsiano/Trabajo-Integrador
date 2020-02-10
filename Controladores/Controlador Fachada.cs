using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Integrador.Dominio;



namespace Trabajo_Integrador.Controladores
{
    public class ControladorFachada
    {
        ///Atributos
        ControladorExamen controladorExamen;
        ControladorAdministrativo controladorAdministrativo;
        /// <summary>
        /// Constructor
        /// </summary>
        public ControladorFachada()
        {
            controladorAdministrativo = new ControladorAdministrativo();
            controladorExamen = new ControladorExamen();
        }

        /// <summary>
        /// Obtiene el tiempo limite que está asociado a un examen
        /// </summary>
        /// <param name="unExamen"></param>
        /// <returns></returns>
        public float GetTiempoLimite(Examen unExamen)
        {
            return controladorExamen.GetTiempoLimite(unExamen);
        }

        /// <summary>
        /// Metodo que inicia un examen
        /// </summary>
        /// <param name="pCantidad"></param>
        /// <param name="pConjunto"></param>
        /// <param name="pCategoria"></param>
        /// <param name="pDificultad"></param>
        /// <returns></returns>
        public Examen InicializarExamen(int pCantidad, String pConjunto, string pCategoria, string pDificultad)
        {
            return controladorExamen.InicializarExamen(pCantidad, pConjunto, pCategoria, pDificultad);
        }
        /// <summary>
        /// Metodo que finaliza un examen y lo guarda en la base de datos
        /// </summary>
        /// <param name="pExamen"></param>
        public void FinalizarExamen(Examen pExamen)
        {
            controladorExamen.FinalizarExamen(pExamen);
        }

        /// <summary>
        /// Metodo que devuelve una lista de todos los usuarios
        /// </summary>
        /// <returns></returns>
        public List<Usuario> GetUsuarios()
        {
            return controladorAdministrativo.GetUsuarios();
        }

        /// <summary>
        /// Metodo que devuelve todas las categorias cargadas en base de datos
        /// </summary>
        /// <returns></returns>
        public List<CategoriaPregunta> GetCategorias()
        {
            return controladorAdministrativo.GetCategorias();
        }
        /// <summary>
        /// Metodo que devuelve todas los conjuntos de preguntas cargados en base de datos
        /// </summary>
        /// <returns></returns>
        public List<ConjuntoPreguntas> GetConjuntoPreguntas()
        {
            return controladorAdministrativo.GetConjuntoPreguntas();
        }
        /// <summary>
        /// Metodo que devuelve todas las dificultades cargadas en base de datos
        /// </summary>
        /// <returns></returns>
        public List<Dificultad> GetDificultades()
        {
            return controladorAdministrativo.GetDificultades();
        }
        /// <summary>
        /// Metodo que guarda un usuario en la base de datos de usuarios
        /// </summary>
        /// <param name="usuarioNombre"></param>
        /// <param name="contrasenia"></param>
        public void GuardarUsuario(string usuarioNombre, string contrasenia)
        {
            controladorAdministrativo.GuardarUsuario(usuarioNombre, contrasenia);
        }

        /// <summary>
        /// Metodo que determina si una respuesta es correcta o no 
        /// </summary>
        /// <param name="pExamen"></param>
        /// <param name="pPregunta"></param>
        /// <param name="pRespuesta"></param>
        /// <returns></returns>
        public Boolean RespuestaCorrecta(Examen pExamen, Pregunta pPregunta, String pRespuesta)
        {
            return controladorExamen.RespuestaCorrecta(pExamen, pPregunta, pRespuesta);
        }
    }
}
