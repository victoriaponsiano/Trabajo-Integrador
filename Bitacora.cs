using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using Trabajo_Integrador.EntityFramework;

namespace Trabajo_Integrador
{
    /// <summary>
    /// Clase bitacora que almacena todos los archivos log para hacer diagnosticos ante errores
    /// </summary>
    public class Bitacora
    {




        /// <summary>
        /// Obtiene un log de la base de datos
        /// </summary>
        /// <param name="pId">Id del log</param>
        /// <returns></returns>
        public Log Obtener(int pId)
        {

            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    return UoW.RepositorioLogs.Get(pId);
                }
            }

        }


        /// <summary>
        /// Agrega un log a la base de datos
        /// </summary>
        /// <param name="pDescripcion"></param>
        public static void GuardarLog(String pDescripcion)
        {

            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    Log log = new Log();
                    log.Descripcion = pDescripcion;
                    log.Fecha = DateTime.Now;
                    UoW.RepositorioLogs.Add(log);
                }
            }

        }
            

        public Bitacora()
        {

        }

        /*
        #region WriteLogError
        /// <summary>
        /// Write an error Log in File
        /// </summary>
        /// <param name="errorMessage"></param>
        public void WriteLogError(string errorMessage)
        {
            try
            {
                string path = "~/Error/" + DateTime.Today.ToString("dd-mm-yy") + ".txt";
                if (!File.Exists(System.Web.HttpContext.Current.Server.MapPath(path)))
                {
                    File.Create(System.Web.HttpContext.Current.Server.MapPath(path))
                    .Close();
                }
                using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath(path)))
                {
                    w.WriteLine("\r\nLog Entry : ");
                    w.WriteLine("{0}", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    string err = "Error in: " + System.Web.HttpContext.Current.Request.Url.ToString()
                                + ". Error Message:" + errorMessage;
                    w.WriteLine(err);
                    w.WriteLine("__________________________");
                    w.Flush();
                    w.Close();
                }
            }
            catch (Exception ex)
            {
                WriteLogError(ex.Message);
            }

        }
        #endregion
        */
    }
}
