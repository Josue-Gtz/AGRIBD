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
                if (string.IsNullOrWhiteSpace(textBox2.Text) && (string.IsNullOrWhiteSpace(textBox3.Text)) && (string.IsNullOrWhiteSpace(textBox4.Text)))
                {
                    OcultarDataGrids();
                    // Ejecución del comando para insertar datos
                    string consultaSQL = "INSERT INTO Productores (nombre, email, direccion) " +
                                     "VALUES ('" + textBox2.Text + "', '" +
                                     textBox3.Text + "', '" + textBox4.Text + "')";

                    // Ejecución de la consulta usando EjecutarComandos
                    var (ds, comando) = SQLSERVER.EjecutarComandos(consultaSQL, "Productores");

                    // Mostrar los resultados en el DataGridView
                    var (lbl, dgv) = SQLSERVER.CrearYMostrarDataGridView(ds, "Productores");
                    this.Controls.Add(lbl);
                    this.Controls.Add(dgv);
                    dgv.Refresh();
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
    }
}
