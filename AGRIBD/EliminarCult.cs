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
    public partial class EliminarCult : Form
    {
        public EliminarCult()
        {
            InitializeComponent();
        }
        ClaseSQLSERVER SQLSERVER = new ClaseSQLSERVER();
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
            //boton
            try
            {
                OcultarDataGrids();

                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Ingrese el ID del cultivo a eliminar.");
                    return;
                }

                // Construcción de la consulta SQL para eliminar
                string consultaSQL = "DELETE FROM Cultivos WHERE id = " + textBox1.Text;

                // Ejecución del comando usando EjecutarComandos
                var (ds, comando) = SQLSERVER.EjecutarComandos(consultaSQL, "Cultivos");

                // Mostrar los datos restantes en el DataGridView
                var (lbl, dgv) = SQLSERVER.CrearYMostrarDataGridView(ds, "Cultivos");
                this.Controls.Add(lbl);
                this.Controls.Add(dgv);
                dgv.Refresh();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el sistema: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
