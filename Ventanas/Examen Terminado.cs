using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabajo_Integrador;
using Trabajo_Integrador.Dominio;
using Trabajo_Integrador.Controladores;

namespace Trabajo_Integrador.Ventanas
{
    public partial class ExamenTerminado : Form
    {
        Examen iExamen;
        ControladorFachada fachada = new ControladorFachada();
        public ExamenTerminado(Examen unExamen)
        {
            InitializeComponent();
            iExamen = unExamen;
        }

        private void ExamenTerminado_Load(object sender, EventArgs e)
        {
            usuarioNombre.Text += iExamen.Usuario.Id;

            tiempo.Text += iExamen.TiempoUsado;

            puntaje.Text += iExamen.Puntaje;

            fecha.Text += iExamen.Fecha;


        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            Close();
            using (Inicio finalizado = new Inicio()) //Paso el examen a la proxima ventana 
                finalizado.ShowDialog();
        }

        private void VolverInicio_Click(object sender, EventArgs e)
        {
            Ventana_Principal volver = new Ventana_Principal(iExamen.Usuario.Id);
            volver.ShowDialog();
        }

        private void volverInicio_Click_1(object sender, EventArgs e)
        {

        }
    }
}

