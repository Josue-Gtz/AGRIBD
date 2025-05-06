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
    public partial class Buscador : Form
    {
        public Buscador()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
        ClaseSQLSERVER SQLSERVER = new ClaseSQLSERVER();    
        private void OcultarDataGrids()
        {
            foreach (var dgv in this.Controls.OfType<DataGridView>())
                dgv.Visible = false;

            foreach (var lbl in this.Controls.OfType<Label>().Where(l => l.Text.StartsWith("Tabla: ")))
                lbl.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OcultarDataGrids();

                string consultaSQL = "";
                string nombreTabla = "";

                // Verifica si se ingresó el ID de Cultivo
                if (!string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    consultaSQL = $"SELECT * FROM Cultivos WHERE Id = {textBox2.Text}";
                    nombreTabla = "Cultivos";
                }
                // Verifica si se ingresó el ID de Productor
                else if (!string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    consultaSQL = $"SELECT * FROM Productores WHERE Id = {textBox1.Text}";
                    nombreTabla = "Productores";
                }
                else
                {
                    MessageBox.Show("Debe ingresar el ID de un Cultivo o un Productor.");
                    return;
                }

                // Ejecutar la consulta
                var (ds, comando) = SQLSERVER.EjecutarComandos(consultaSQL, nombreTabla);

                // Validar si hay datos
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    // Usar BindingSource para llenar el DataGridView
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = ds.Tables[0];

                    // Crear y mostrar el DataGridView
                    DataGridView dgv = new DataGridView
                    {
                        DataSource = bindingSource,
                        Dock = DockStyle.Fill // Ajustar el tamaño del DataGridView
                    };

                    // Opcional: Agregar filtros en el BindingSource si es necesario
                    // Aquí puedes hacer algún filtrado si se requiere
                    // Ejemplo de filtro:
                    // bindingSource.Filter = "Nombre LIKE '%algún valor%'";

                    // Crear el Label
                    Label lbl = new Label
                    {
                        Text = nombreTabla,
                        Dock = DockStyle.Top
                    };

                    // Agregar los controles al formulario
                    this.Controls.Add(lbl);
                    this.Controls.Add(dgv);
                    dgv.Refresh();
                }
                else
                {
                    MessageBox.Show("No se encontró ningún registro con ese ID.");
                }
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
    }
}
