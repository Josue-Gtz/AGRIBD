using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGRIBD
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;

        }
        public delegate void LoginSuccessHandler(string usuario, string rol);
        public event LoginSuccessHandler OnLoginSuccess;
        private void button1_Click(object sender, EventArgs e)
        {
            //boton Inicio
            string user = textBox1.Text;
            string pass = textBox2.Text;

            if (user == "admin" && pass == "carpincho")
            {
                OnLoginSuccess?.Invoke(user, "Admin");
                this.Close();
            }
            else if (user == "cliente" && pass == "invisible")
            {
                OnLoginSuccess?.Invoke(user, "Cliente");
                this.Close();
            }
            else if (user == "productor" && pass == "yo:gurt")
            {
                OnLoginSuccess?.Invoke(user, "Productor");
                this.Close();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas");
            }
        }
    }
}
