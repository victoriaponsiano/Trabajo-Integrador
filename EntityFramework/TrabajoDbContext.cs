using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Integrador.Dominio;

namespace Trabajo_Integrador.EntityFramework
{
    /// <summary>
    /// Representa una conexion con la base de datos para acceder a los examenes.
    /// </summary>
    public class TrabajoDbContext : DbContext
    {
        public DbSet<Examen> Examenes { get; set; } 
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pregunta> Preguntas { get; set; }
        public DbSet<ConjuntoPreguntas> ConjuntoPreguntas { get; set; }
    }
}
