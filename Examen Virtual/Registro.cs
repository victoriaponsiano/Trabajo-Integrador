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
    public partial class Registro : Form
    {
        string usuarioNombre;
        string contrasenia;

        public Registro()
        {
            InitializeComponent();
        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Registrar_Click(object sender, EventArgs e)
        {
            if (nuevoUsuario.Text.Trim() != string.Empty)
            {
                usuarioNombre = nuevoUsuario.Text;
                errorProvider2.SetError(nuevoUsuario, "");
            }
            else { errorProvider2.SetError(nuevoUsuario, "Debe ingresar un usuario");
                nuevoUsuario.Focus();
            }

            if (nuevaContrasenia==nuevaContrasenia2)
            {
                contrasenia = nuevaContrasenia.Text;
                errorProvider1.SetError(nuevaContrasenia, "");
            }
            else
            {
                errorProvider1.SetError(nuevaContrasenia, "Las contraseñas ingresadas no coinciden");
                nuevaContrasenia.Focus();
            }

            //Usuario user = new Usuario(usuarioNombre, contrasenia)
                ;
        }
    }
}
