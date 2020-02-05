using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Integrador.EntityFramework
{
    public class RepositorioConjuntoPregunta : Repository<Pregunta, TrabajoDbContext>
    {
        public RepositorioConjuntoPregunta(TrabajoDbContext pContext) : base(pContext) { }
    }
}
