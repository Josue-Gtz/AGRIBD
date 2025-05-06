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
    public partial class Main : Form
    {
        public string UsuarioActual { get; set; }
        public string RolActual { get; set; }
        public Main()
        {
            InitializeComponent();
            cultivosToolStripMenuItem.Visible = false;
            productoresToolStripMenuItem.Visible = false;
            reportesToolStripMenuItem.Visible = false;
            buscarToolStripMenuItem.Visible = false;

        }

        private void LoginExitoso(string usuario, string rol)
        {
            this.UsuarioActual = usuario;
            this.RolActual = rol;

            MostrarOpcionesPorRol(rol);
        }

        private void MostrarOpcionesPorRol(string rol)
        {
            cultivosToolStripMenuItem.Visible = false;
            productoresToolStripMenuItem.Visible = false;
            reportesToolStripMenuItem.Visible = false;
            buscarToolStripMenuItem.Visible = false;


            switch (rol)
            {
                case "Cliente":
                    buscarToolStripMenuItem.Visible = true;
                    reportesToolStripMenuItem.Visible = true;

                    break;
                case "Productor":
                    cultivosToolStripMenuItem.Visible = true;
                    productoresToolStripMenuItem.Visible = true;
                    reportesToolStripMenuItem.Visible = true;
                    buscarToolStripMenuItem.Visible = true;
                    break;
                case "Admin":
                    cultivosToolStripMenuItem.Visible = true;
                    productoresToolStripMenuItem.Visible = true;
                    reportesToolStripMenuItem.Visible = true;
                    buscarToolStripMenuItem.Visible = true;
                    break;
            }
        }

        private void administradorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Buscador Buscar = new Buscador();
            Buscar.MdiParent = this;
            Buscar.Show();
        }

        private void cultivosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login login = new Login();  
            login.MdiParent= this;
            login.OnLoginSuccess += LoginExitoso;
            login.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void registraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegisCult prod = new RegisCult();
            prod.MdiParent = this;
            prod.Show();
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarCult RegistrarCul = new RegistrarCult();
            RegistrarCul.MdiParent = this;
            RegistrarCul.Show();
        }

        private void eliminarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EliminarCult EliminarCul = new EliminarCult();
            EliminarCul.MdiParent = this;
            EliminarCul.Show();
        }

        private void editarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EditarCult EditarCul = new EditarCult();
            EditarCul.MdiParent = this;
            EditarCul.Show();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EliminarProductor EliminarPro = new EliminarProductor();
            EliminarPro.MdiParent = this;
            EliminarPro.Show();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditarProductor EditarPro = new EditarProductor();
            EditarPro.MdiParent = this;
            EditarPro.Show();
        }

        private void asignarCultivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetallesAsig asig = new DetallesAsig();
            asig.MdiParent = this;
            asig.Show();
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reportes reportes = new Reportes();
            reportes.MdiParent = this;
            reportes.Show();
        }
    }
}
