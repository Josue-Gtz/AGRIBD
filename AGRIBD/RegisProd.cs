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
    public partial class RegisCult : Form
    {
        ClaseSQLSERVER SQLSERVER = new ClaseSQLSERVER();
        public RegisCult()
        {
            InitializeComponent();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Boton para añadir
            try
            {
                OcultarDataGrids();
                // Ejecución del comando para insertar datos
                string consultaSQL = "INSERT INTO Cultivos (id, nombre, cultivo, direccion) " +
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
    }
}
