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
using Trabajo_Integrador.Controladores;

namespace Trabajo_Integrador.Ventanas
{
    
    public partial class Ventana_Lista_Examenes : Form
    {
        ControladorFachada fachada = new ControladorFachada();

        public Ventana_Lista_Examenes()
        {
            InitializeComponent();
        }

        private void Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void Ventana_Lista_Examenes_Load(object sender, EventArgs e)
        {
            List<Examen> listaExamenes = fachada.GetExamenes();
            DataTable dt = new DataTable();
            dt.Columns.Add("Usuario", typeof(string));
            dt.Columns.Add("Fecha", typeof(DateTime));
            dt.Columns.Add("Puntaje", typeof(int));
            dt.Columns.Add("Tiempo", typeof(float));

            foreach (Examen examen in listaExamenes)
            {
                dt.Rows.Add(new object[] { examen.Usuario, examen.Fecha, examen.Puntaje, examen.TiempoUsado });
            }

            dataGridView1.DataSource = dt;
        }
    }
}
