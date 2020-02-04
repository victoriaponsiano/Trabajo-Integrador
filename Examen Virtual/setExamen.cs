using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_Virtual
{
    public partial class setExamen : Form
    {
        string nombreCliente;
        string[] categorias = { "Aleatoria", "Libros", "Peliculas", "Musica", "Television", "Videojuegos", "Computacion", "Matemática", "Naturaleza" };
        string[] dificultades = { "Aleatoria", "Facil", "Media", "Dificil" };



        public setExamen(string nombre)
        {
            InitializeComponent();
            nombreCliente = nombre; //Usado para mostrar en el Bienvenido
            
        }


        private void setExamen_Load(object sender, EventArgs e)
        {
            saludo.Text += nombreCliente; //Nombre que aparece junto con el Bienvenido 

            cargarCategoria();
            cargarDificultad();
        }

        private void cargarCategoria()
        {
            for (int i=0; i<categorias.Length; i++)
            {
                categoria.Items.Add(categorias[i]); //Le asigno al combobox categoria el array categorias
            }
        }

        private void cargarDificultad()
        {
            for (int i=0; i<dificultades.Length; i++)
            {
                dificultad.Items.Add(dificultades[i]);  //Le asigno al combobox dificultad el array dificultades
            }
        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


}
