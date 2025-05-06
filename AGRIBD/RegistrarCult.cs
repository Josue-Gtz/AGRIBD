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
            //Boton para que se añada
            try
            {
                OcultarDataGrids();
                // Ejecución del comando para insertar datos
                string consultaSQL = "INSERT INTO Cultivos (id, nombre, plantacion, tamaño) " +
                                 "VALUES (" + textBox1.Text + ", '" + textBox2.Text + "', '" +
                                 textBox3.Text + "', '" + textBox4.Text + "')";

                // Ejecución de la consulta usando EjecutarComandos
                var (ds, comando) = SQLSERVER.EjecutarComandos(consultaSQL, "Cultivos");

                // Mostrar los resultados en el DataGridView
                var (lbl, dgv) = SQLSERVER.CrearYMostrarDataGridView(ds, "Cultivos");
                this.Controls.Add(lbl);
                this.Controls.Add(dgv);
                dgv.Refresh();
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
