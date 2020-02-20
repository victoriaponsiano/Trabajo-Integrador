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
    public partial class configurarExamen : Form
    {
        String iNombreUsuario;
        ControladorFachada fachada = new ControladorFachada();

        
        List<CategoriaPregunta> cate;
        List<ConjuntoPreguntas> conj;
        List<Dificultad> dific;

        public configurarExamen(String pNombreUsuario)
        {
            InitializeComponent();
            iNombreUsuario = pNombreUsuario; //Usado para mostrar en el Bienvenido

        }


        private void setExamen_Load(object sender, EventArgs e)
        {
            saludo.Text += iNombreUsuario; //Nombre que aparece junto con el Bienvenido 

            cargarCategoria();
            cargarDificultad();
            cargarConjunto();
        }

        private void cargarCategoria()
        {
            cate = fachada.GetCategorias();

            List<string> listaCategorias = new List<string>(); ;
            foreach (CategoriaPregunta cat in cate)
            {
                listaCategorias.Add(cat.Id);
            }

            string[] categorias= listaCategorias.ToArray();
             
            for (int i = 0; i < categorias.Length; i++)
            {
                categoria.Items.Add(categorias[i]); //Le asigno al combobox categoria el array categorias
            }
        }



        private void cargarDificultad() //Le asigno al combobox dificultad el array dificultades
        {
            dific = fachada.GetDificultades();
            
            List<string> listaDificultades = new List<string>(); ;
            foreach (Dificultad dif in dific)
            {
                listaDificultades.Add(dif.Id);
            }

            string[] dificultades = listaDificultades.ToArray();

            for (int i = 0; i < dificultades.Length; i++)
            {
                dificultad.Items.Add(dificultades[i]); //Le asigno al combobox dificultad el array dificultades
            }
        }
    

        private void cargarConjunto()   //Le asigno al combobox conjunto el array conjunto
        {
            conj = fachada.GetConjuntoPreguntas();
        
             List<string> listaConjuntos = new List<string>(); 

                foreach (ConjuntoPreguntas con in conj)
                {
                    listaConjuntos.Add(con.Id);
                }

            string[] conjuntos = listaConjuntos.ToArray();

            for (int i = 0; i < conjuntos.Length; i++)
            {
                conjunto.Items.Add(conjuntos[i]); //Le asigno al combobox categoria el array categorias
            }
        }


        private void volver_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (fachada.EsAdministrador(iNombreUsuario))
            {
                Ventana_Principal_Admi vAdmin = new Ventana_Principal_Admi(iNombreUsuario);
                vAdmin.ShowDialog();
            }
            else { Ventana_Principal vPrinicpal = new Ventana_Principal(iNombreUsuario);
                vPrinicpal.ShowDialog();
            }
            this.Close();
        }

        private void btnComenzarExamen_Click(object sender, EventArgs e)
        {


            string categoriaSeleccionada = categoria.SelectedItem.ToString(); //Asigno el valor ingresado a clase Categoria

            string dificultadSeleccionada = dificultad.SelectedItem.ToString(); //Asigno el valor ingresado a clase Dificultad

            string conjuntoSeleccionado = conjunto.SelectedItem.ToString(); //Asigno el valor ingresado a clase Dificultad

            int cantidadSeleccionada = Convert.ToInt32(cantidadPreguntas.Value); //Cantidad de preguntas a responder     

            

            Examen nuevoExamen = fachada.InicializarExamen(cantidadSeleccionada, conjuntoSeleccionado, categoriaSeleccionada, dificultadSeleccionada);
            fachada.InicarExamen(iNombreUsuario, nuevoExamen);

            this.Hide();

            using (VPreguntas Vpreguntas = new VPreguntas(nuevoExamen)) 
                Vpreguntas.ShowDialog();
            this.Close();

        }

    }


}
