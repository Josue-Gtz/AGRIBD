using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AGRIBD
{
    public partial class RegistrarCult : Form
    {
        private string Servidor = "JOSUE\\SQLEXPRESS";
        private string Basedatos = "ESCOLAR";
        private string UsuarioId = "sa";
        private string Password = "2050";
        ClaseSQLSERVER SQLSERVER = new ClaseSQLSERVER();    
        public RegistrarCult()
        {
            InitializeComponent();
        }

        
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void OcultarDataGrids()
        {
            foreach (var dgv in this.Controls.OfType<DataGridView>())
            {
                dgv.Visible = false;
            }
            foreach (var lbl in this.Controls.OfType<Label>().Where(l => l.Text.StartsWith("Tabla: ")))
            {
                lbl.Visible = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(textBox2.Text) && (!string.IsNullOrWhiteSpace(textBox3.Text)) && (!string.IsNullOrWhiteSpace(textBox4.Text)))
                {
                    OcultarDataGrids();
                    string consultaSQL = "INSERT INTO Cultivos (nombre, plantacion, tamaño) " +
                                     "VALUES ('" + textBox2.Text + "', '" +
                                     textBox3.Text + "', '" + textBox4.Text + "')";

                    var (ds, comando) = SQLSERVER.EjecutarComandos(consultaSQL, "Cultivos");

                    var (lbl, dgv) = SQLSERVER.CrearYMostrarDataGridView(ds, "Cultivos");
                    this.Controls.Add(lbl);
                    this.Controls.Add(dgv);
                    dgv.Refresh();
                    MessageBox.Show("Cultivo registrado");
                }
                else
                {
                    MessageBox.Show("Todos los espacios deben estar llenos");
                }
            }
            catch (SqlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error en el sistema: " + Ex.Message);
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
               

            }
            else
            {
                e.KeyChar = (char)0;
                MessageBox.Show("Solo numeros");

            }


        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void RegistrarCult_Load(object sender, EventArgs e)
        {

        }
    }
}
