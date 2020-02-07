﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Examen_Virtual;
using Trabajo_Integrador.Dominio;


namespace Trabajo_Integrador
{
    public partial class setExamen : Form
    {
        string nombreCliente;
        ControladorFachada fachada = new ControladorFachada();

        string[] categorias = { "Aleatoria", "Libros", "Peliculas", "Musica", "Television", "Videojuegos", "Computacion", "Matemática", "Naturaleza" };
        string[] dificultades = { "Aleatoria", "Facil", "Media", "Dificil" };
        CategoriaPregunta[] cate = { };
        ConjutoPregunta[] conj = { };
        Dificultad[] dific = { };

        //List.toArray(); PARA CONVERTIR LA LISTA DE BASE D DATOS EN UN ARRAY DE STRING



        public setExamen(string nombre)
        {
            InitializeComponent();
            nombreCliente = nombre; //Usado para mostrar en el Bienvenido

            saludo.Text += nombreCliente; //Nombre que aparece junto con el Bienvenido 

            cargarCategoria();
            cargarDificultad();
            cargarConjunto();

        }


        private void setExamen_Load(object sender, EventArgs e)
        {
            saludo.Text += nombreCliente; //Nombre que aparece junto con el Bienvenido 

            cargarCategoria();
            cargarDificultad();
        }

        private void cargarCategoria()
        {
            for (int i=0; i<cate.Length; i++)
            {
                categoria.Items.Add(cate[i]); //Le asigno al combobox categoria el array categorias
            }
        }

        private void cargarDificultad() //Le asigno al combobox dificultad el array dificultades
        {
            for (int i=0; i<dific.Length; i++)
            {
                dificultad.Items.Add(dific[i]);  
            }
        }

        private void cargarConjunto()   //Le asigno al combobox conjunto el array conjunto
        {
            for (int i = 0; i < conj.Length; i++)
            {
                dificultad.Items.Add(conj[i]);
            }
        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnComenzarExamen_Click(object sender, EventArgs e)
        {
            string categoriaSeleccionada = categoria.SelectedItem.ToString().ToLower(); //Asigno el valor ingresado a clase Categoria

            string dificultadSeleccionada = dificultad.SelectedItem.ToString().ToLower(); //Asigno el valor ingresado a clase Dificultad


            int cantidadSeleccionada = Convert.ToInt32(cantidadPreguntas.Value); //Cantidad de preguntas a responder

            string conjuntoSeleccionado = conjunto.SelectedItem.ToString().ToLower(); //Asigno el valor ingresado a clase Dificultad



            Examen nuevoExamen = fachada.InicializarExamen(cantidadSeleccionada, conjuntoSeleccionado, categoriaSeleccionada, dificultadSeleccionada);

            using (Pregunta preguntas = new Pregunta(nuevoExamen)) //Le paso el usuario para que aparezca en la proxima ventana
                preguntas.ShowDialog();

        }
    }


}
