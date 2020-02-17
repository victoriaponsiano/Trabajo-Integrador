﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabajo_Integrador.Controladores;

namespace Trabajo_Integrador.Ventanas
{
    public partial class Todas_las_Preguntas : Form
    {
        public Todas_las_Preguntas()
        {
            InitializeComponent();
        }
        ControladorFachada fachada = new ControladorFachada();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            List<Pregunta> listaPreguntas = fachada.GetPreguntas();
            DataTable dt = new DataTable();
            //dt.Columns.Add("Usuario", typeof(string));
            dt.Columns.Add("Pregunta", typeof(string));
            dt.Columns.Add("Respuesta Correcta", typeof(string));
            dt.Columns.Add("Respuesta Incorrecta 1", typeof(string));
            dt.Columns.Add("Respuesta Incorrecta 2", typeof(string));
            dt.Columns.Add("Respuesta Incorrecta 3", typeof(string));

            foreach (Pregunta pregunta in listaPreguntas)
            {
                dt.Rows.Add(new object[] { pregunta.Id, pregunta.RespuestaCorrecta, pregunta.RespuestaIncorrecta1, pregunta.RespuestaIncorrecta2, pregunta.RespuestaIncorrecta3});
            }

            dataGridView1.DataSource = dt;
        }
    }
}
