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
                if (!string.IsNullOrWhiteSpace(textbox1.Text))
                {
                    // Ejecución del comando para buscar datos
                    var (ds, comando) = SQLSERVER.EjecutarComandos($"SELECT * FROM Productores WHERE Nombre = '{textbox1.Text}'", "Productores");
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.Read())
                    {
                        DataRow row = ds.Tables["Productores"].Rows[0];
                        textBox3.Text = row["Id"].ToString();
                        textBox4.Text = row["Email"].ToString();
                        textBox5.Text = row["Direccion"].ToString();
                        MessageBox.Show("Productor encontrado");


                    }
                    else
                    {
                        MessageBox.Show("Productor no encontrado");
                    }
                    
                }
                if (!string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    OcultarDataGrids();
                    // Ejecución del comando para buscar datos
                    var (ds, comando) = SQLSERVER.EjecutarComandos($"SELECT * FROM Cultivos WHERE Nombre = '{textBox2.Text}'", "Cultivos");
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.Read())
                    {
                        DataRow row = ds.Tables["Cultivos"].Rows[0];
                        textBox6.Text = row["Id"].ToString();
                        textBox7.Text = row["Plantacion"].ToString();
                        textBox8.Text = row["Tamaño"].ToString();
                        MessageBox.Show("Productor encontrado");


                    }
                    else
                    {
                        MessageBox.Show("Cultivo no encontrado.");
                    }


                }
                else if (!string.IsNullOrWhiteSpace(textbox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    {
                        MessageBox.Show("Ingrese algun nombre");
                    }
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
