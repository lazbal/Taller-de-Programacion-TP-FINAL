using System;
using System.Windows.Forms;
using CapaEntidad;

namespace CapaVisual
{
    public partial class Login : Form
    {
        private string iUsuario;
        private string iContraseña;

        public Login()
        {
            InitializeComponent();
            textContraseña.PasswordChar = '*';
            iUsuario = "";
            iContraseña = "";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (textUsuario.Text == iUsuario && textContraseña.Text == iContraseña)
            {
                this.Hide();
                AdminCarteleria iAdministrador = new AdminCarteleria();
                iAdministrador.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("El usuario o contraseña ingresador no son correctos.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textContraseña_KeyPress(object sender, KeyPressEventArgs keyPress)
        {
            if ((int)keyPress.KeyChar == (int)Keys.Enter)
            {
                btnAceptar_Click(sender, keyPress);
            }
        }
    }
}
