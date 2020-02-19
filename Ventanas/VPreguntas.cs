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
using Trabajo_Integrador;
using Trabajo_Integrador.Controladores;

namespace Trabajo_Integrador.Ventanas
{
    public partial class VPreguntas : Form
    {
        Examen iExamen;
        ControladorFachada fachada = new ControladorFachada();
      

        public VPreguntas(Examen unExamen)
        {
            InitializeComponent();
            iExamen = unExamen;
            //iNumeroPreguntas = unExamen.CantidadPreguntas;

        }

        float tiempo;
        

        public void mostrarPregunta(Pregunta unaPregunta) //Muestra una pregunta con sus opciones
        {
            preg.Text += unaPregunta.Id; //Muestro la Pregunta en el Label

            List<string> opciones = new List<string>(); //Almacena las 4 opciones de respuestas

            opciones.Add(unaPregunta.RespuestaCorrecta);
            opciones.Add(unaPregunta.RespuestaIncorrecta1);
            opciones.Add(unaPregunta.RespuestaIncorrecta2);
            opciones.Add(unaPregunta.RespuestaIncorrecta3);


            List<string> listaDesordenada = new List<string>();
            Random rnd = new Random();

            while (opciones.Count > 0) //Desordena la Lista 
            {
                int i = rnd.Next(opciones.Count);
                listaDesordenada.Add(opciones[i]);
                opciones.RemoveAt(i);
            }

            opcionA.Text += listaDesordenada[0]; //Muestro la opcion A
            opcionB.Text += listaDesordenada[1]; //Muestro la opcion B
            opcionC.Text += listaDesordenada[2]; //Muestro la opcion C
            opcionD.Text += listaDesordenada[3]; //Muestro la opcion D

            

        }

        public string RecogerOpcion(Examen pExamen, Pregunta pPregunta) //Devuelve cual fue la opcion Seleccionada
        {
         
                string respuesta = string.Empty;

                if (opcionA.Checked == true) { respuesta = "A"; }
                if (opcionB.Checked == true) { respuesta = "B"; }
                if (opcionC.Checked == true) { respuesta = "C"; }
                if (opcionD.Checked == true) { respuesta= "D"; }



            return respuesta;
        }

        

        public void responderPregunta() //mUESTRA LAS PREGUNTAS DEL EXAMEN
        {
            tiempo = iExamen.TiempoLimite;
            this.time.Text = tiempo.ToString();
            this.timer.Enabled = true;

            List<Pregunta> listaPreguntas = fachada.GetPreguntas();
            foreach (Pregunta pregunta in listaPreguntas)
            {
                mostrarPregunta(pregunta);
                string respuesta= RecogerOpcion(iExamen, pregunta);
                fachada.RespuestaCorrecta(iExamen, pregunta, respuesta);
                siguiente_Click(siguiente, EventArgs.Empty);

                //Console.ReadKey();
                //siguiente.PerformClick();


            }
        }



            //}
            //    Pregunta pregunta = obtienePregunta(pNumeroPregunta);

            //    mostrarPregunta(pregunta);

            //    Boolean respuesta = RecogerOpcion(iExamen, pregunta);
            
            //else
            //{
            //    fachada.FinalizarExamen(iExamen);
            //}
        
                

        //public Pregunta obtienePregunta(int numeroPregunta)
        //{
        //    List<Pregunta> listaPreguntas = iExamen.getPreguntas();
        //    return listaPreguntas[numeroPregunta];
        //}


        public void LimpiaControles() //Limpia todos los campos (textBox y checkBox)
        {
            
            preg.Text = "*";

            opcionA.Text = String.Empty;
            opcionB.Text = String.Empty;
            opcionC.Text = String.Empty;
            opcionD.Text = String.Empty;

            opcionA.Checked = false;
            opcionB.Checked = false;
            opcionC.Checked = false;
            opcionD.Checked = false;

        }


        private void timer_Tick(object sender, EventArgs e) //Tiempo agotado
        {
            tiempo--;
            this.time.Text = tiempo.ToString();
            if (tiempo == 0) //Termino el tiempo limite
            {
                this.timer.Enabled = false;
                fachada.FinalizarExamen(iExamen);
                using (ExamenTerminado finalizado = new ExamenTerminado(iExamen)) //Paso el examen a la proxima ventana 
                    finalizado.ShowDialog();
            }


        }


        private void siguiente_Click(object sender, EventArgs e)
        {
            //Button siguiente = (Button)sender;
            MessageBox.Show("Esta en click siguiente");
            LimpiaControles();

        }
        

        private void VPreguntas_Load(object sender, EventArgs e)
        {
            tiempo = iExamen.TiempoLimite;
            this.time.Text = tiempo.ToString();

            responderPregunta();
            
        }

      
    }



}
