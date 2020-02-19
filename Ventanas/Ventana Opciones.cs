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
    public partial class Ventana_Opciones : Form
    {

        public Ventana_Opciones()
        {
            InitializeComponent();
        }

        private void listaUsuarios_Click(object sender, EventArgs e)
        {
            Ventana_Lista_Usuarios listaUsuarios = new Ventana_Lista_Usuarios();
            listaUsuarios.ShowDialog();
        }

        private void verExamenes_Click(object sender, EventArgs e)
        {
            Ventana_Lista_Examenes listaExamenes = new Ventana_Lista_Examenes();
            listaExamenes.ShowDialog();
        }

        //private void cargarExamenes_Click(object sender, EventArgs e)
        //{
        //    fachada.CargarPreguntas();
        //}

        private void setAdministrador_Click(object sender, EventArgs e)
        {
            SetAdministrador setAdministrador = new SetAdministrador();
            setAdministrador.ShowDialog();



        }

        private void verPreguntas_Click(object sender, EventArgs e)
        {
            Todas_las_Preguntas preguntas = new Todas_las_Preguntas();
            preguntas.ShowDialog();
        }

        private void modificarTiempos_Click(object sender, EventArgs e)
        {
            Ventana_Modificar_Tiempo tiempos = new Ventana_Modificar_Tiempo();
            tiempos.ShowDialog();
        }

       

        private void volver_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
