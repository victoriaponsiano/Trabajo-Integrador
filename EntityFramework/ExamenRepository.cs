using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Integrador.EntityFramework
{
    class ExamenRepository : Repository<Examen,TrabajoDbContext>{
        public ExamenRepository(TrabajoDbContext pContext) : base(pContext)
            { }
        
    }
}

