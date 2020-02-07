using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabajo_Integrador.Dominio;

namespace Examen_Virtual
{
    public partial class Pregunta : Form
    {
        Examen iExamen;
        public Pregunta(Examen unExamen)
        {
            InitializeComponent();
            iExamen = unExamen;
        }

        public List<Pregunta> getPreguntas()
        public void mostrarPreguntas()
        {
            

        }
     

       
    }
}
