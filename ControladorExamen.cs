using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Integrador
{
    public class ControladorExamen
    {
        public void GuardarExamen(Examen pExamen) {
            
                using (var db = new ExamenDbContext())
                {
                db.Examenes.Add(pExamen);
                db.SaveChanges();
                }
            
           
        }
    }
}
