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

namespace Trabajo_Integrador.Ventanas
{
    public partial class Ventana_Principal : Form
    {
        String iNombreUsuario;

        public Ventana_Principal(string unUsuario)
        {
            InitializeComponent();
            iNombreUsuario = unUsuario;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            configurarExamen ex = new configurarExamen(iNombreUsuario);
            ex.ShowDialog();
                

        }

        private void Ventana_Principal_Load(object sender, EventArgs e)
        {
            user.Text += iNombreUsuario;
        }
    }
}
