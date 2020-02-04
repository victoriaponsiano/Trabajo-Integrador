using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Integrador.EntityFramework
{
    /// <summary>
    /// Representa una conexion con la base de datos para acceder a los examenes.
    /// </summary>
    class TrabajoDbContext : DbContext
    {
        public DbSet<Examen> Examenes { get; set; } 
    }
}
