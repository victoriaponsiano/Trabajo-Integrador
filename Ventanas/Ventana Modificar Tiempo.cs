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
    public partial class Ventana_Modificar_Tiempo : Form
    {
        public Ventana_Modificar_Tiempo()
        {
            InitializeComponent();
        }

        List<ConjuntoPreguntas> conjuntos;
        ControladorFachada fachada = new ControladorFachada();


        private void modificar_Click(object sender, EventArgs e)
        {

            string conjuntoSeleccionado = ListaConjuntos.SelectedItem.ToString();
            float tiempoIngresado = float.Parse(tiempo.SelectedText);
            fachada.ModificarTiempo(conjuntoSeleccionado, tiempoIngresado);
            MessageBox.Show("Tiempo modificado con Exito");
        }

        private void volver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Ventana_Modificar_Tiempo_Load(object sender, EventArgs e)
        {
            CargarConjunto();
        }

        private void CargarConjunto()
        {

            conjuntos = fachada.GetConjuntoPreguntas();

            List<string> listaConjuntos = new List<string>();

            foreach (ConjuntoPreguntas conjunto in conjuntos)
            {
                listaConjuntos.Add(conjunto.Id);
            }

            string[] conjuntosArray = listaConjuntos.ToArray();

            for (int i = 0; i < conjuntosArray.Length; i++)
            {

                ListaConjuntos.Items.Add(conjuntos[i]); //Le asigno al combobox categoria el array categorias
            }
        } //Muestra todos los conjuntos disponibles en el combobox ListaConjuntos

    }
}

