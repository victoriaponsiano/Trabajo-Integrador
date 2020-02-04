using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Integrador
{
    /// <summary>
    /// Representa una conexion con la base de datos para acceder a los examenes.
    /// </summary>
    class ExamenDbContext : DbContext
    {
        public DbSet<Examen> Examenes { get; set; }
    }
}
