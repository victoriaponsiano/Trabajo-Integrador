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
    public partial class Ventana_Lista_Usuarios : Form
    {
        ControladorFachada fachada = new ControladorFachada();

        public Ventana_Lista_Usuarios()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            List<Usuario> listaUsuarios= fachada.GetUsuarios();
            DataTable dt = new DataTable();
            //dt.Columns.Add("Usuario", typeof(string));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Contraseña", typeof(string));
            //dt.Columns.Add("Tiempo", typeof(float));

            foreach (Usuario usuario in listaUsuarios)
            {
                dt.Rows.Add(new object[] { usuario.Id, usuario.Contrasenia}) ;
            }

            dataGridView1.DataSource = dt;
        }

        private void Volver_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
