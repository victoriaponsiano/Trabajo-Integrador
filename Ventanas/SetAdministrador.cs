using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabajo_Integrador.Controladores;
using Trabajo_Integrador.Dominio; 


namespace Trabajo_Integrador.Ventanas
{
    public partial class SetAdministrador : Form
    {
        ControladorFachada fachada = new ControladorFachada();
        public SetAdministrador()
        {
            InitializeComponent();
        }

        string nombreUsuario;
        private void setAdmin_Click(object sender, EventArgs e)
        {
            nombreUsuario = usuario.Text;
            fachada.SetAdministrador(nombreUsuario);
            MessageBox.Show("El usuario" +nombreUsuario, "fue configurado como administrador con Exito");
            
        }

        private void Volver_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
