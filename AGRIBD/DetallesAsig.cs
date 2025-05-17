using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AGRIBD
{
    public partial class DetallesAsig : Form
    {
        public DetallesAsig()
        {
            InitializeComponent();
        }

        ClaseSQLSERVER SQLSERVER = new ClaseSQLSERVER();
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text) && (string.IsNullOrWhiteSpace(textBox1.Text)))
            {
                if (int.TryParse(textBox1.Text, out int idprod) && int.TryParse(textBox2.Text, out int idcult))
                {
                    // Verificar si existe el Productor
                    string consultaProductor = $"SELECT COUNT(*) FROM Productores WHERE Id = {idprod}";
                    int countProductor = SQLSERVER.ObtenerCantidad(consultaProductor);

                    if (countProductor == 0)
                    {
                        MessageBox.Show("ID de Productor inválido.", "Error");
                        return;
                    }

                    // Verificar si existe el Cultivo
                    string consultaCultivo = $"SELECT COUNT(*) FROM Cultivos WHERE Id = {idcult}";
                    int countCultivo = SQLSERVER.ObtenerCantidad(consultaCultivo);

                    if (countCultivo == 0)
                    {
                        MessageBox.Show("ID de Cultivo inválido.", "Error");
                        return;
                    }

                    // Insertar solo si ambos existen
                    string insertQuery = $@"
            INSERT INTO Detalles (Id_productor, Id_cultivo)
            VALUES ({idprod}, {idcult});";

                    var resultado = SQLSERVER.EjecutarComandos(insertQuery, "Detalles");

                    if (resultado.Item2 != null)
                    {
                        MessageBox.Show("Cultivo asignado correctamente al productor.", "Éxito");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor ingresa IDs numéricos válidos.", "Error");
                }
            }
            else
            {
                MessageBox.Show("Todos los espacios deben estar llenos");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
