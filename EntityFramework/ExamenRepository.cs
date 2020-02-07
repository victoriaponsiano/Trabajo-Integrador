using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Integrador.EntityFramework;
using Trabajo_Integrador.Dominio;

namespace Trabajo_Integrador.EntityFramework
{
    public class ExamenRepository : Repository<Examen,TrabajoDbContext>{
        public ExamenRepository(TrabajoDbContext pContext) : base(pContext)
            { }
        
    }
}

