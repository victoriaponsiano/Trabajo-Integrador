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
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }


        private void btnSalir_Click(object sender, EventArgs e) //Boton Salir 
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            using (setExamen ventantaSetExamen = new setExamen(usuario.Text)) //Le paso el usuario para que aparezca en la proxima ventana
                ventantaSetExamen.ShowDialog(); 
        }

        private void Inicio_Load(object sender, EventArgs e) //Se ejeecuta el codigo cuando el formulario se carga
        {
            btnIngresar.Enabled = false;
        }

        private void usuario_TextChanged(object sender, EventArgs e) //Ingreso de Usuario
        {
            controlBoton(); 
        }

        //SOLUCIONAR PROBLEMA DE LISTA DE USUARIO PARA QUE USUARIO SEA UNO EXISTENTE Y CONTRASEÑA TAMBIEN.
        //Trim saca espacios al texto ingresado

       // BDUsuario listaUser = List<BDUsuario>;***********
        
        private void controlBoton()
        {
            if (usuario.Text.Trim()!=string.Empty) // && (Busqueda en listaUsuarios (usuario.Text.Trim())== true)  
            {
                btnIngresar.Enabled= true; //Se habilita en boton Ingresar
                errorProvider1.SetError(usuario, ""); //No hubo error
            }
            else //Contraseña y/o usuario incorrectos y/o campos vacios
            {
                btnIngresar.Enabled = false;    //Se deshabilita boton Ingresar
                errorProvider1.SetError(usuario, "El usuario y/o contraseña son incorrectos"); //Cartel de Error 
                usuario.Focus();//Hace foco en el botón Usuario 
                contrasenia.Focus();

            }


        }

        private void crearUsuario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (Registro registro = new Registro()) //Le paso el usuario para que aparezca en la proxima ventana
                registro.ShowDialog(); 
        }
    }
}
