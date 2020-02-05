using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Integrador.EntityFramework
{
    public class RepositorioPreguntas : Repository<Pregunta, TrabajoDbContext>
    {
        public RepositorioPreguntas(TrabajoDbContext pContext) : base(pContext) { }
    }
}
