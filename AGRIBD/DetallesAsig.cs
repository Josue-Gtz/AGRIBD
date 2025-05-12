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
    public partial class DetallesAsig : Form
    {
        public DetallesAsig()
        {
            InitializeComponent();
        }

        ClaseSQLSERVER SQLSERVER = new ClaseSQLSERVER();
        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int productorId) && int.TryParse(textBox2.Text, out int cultivoId))
            {
                // Verificar si existe el Productor
                string consultaProductor = $"SELECT COUNT(*) FROM Productores WHERE Id = {productorId}";
                int countProductor = SQLSERVER.ObtenerCantidad(consultaProductor);

                if (countProductor == 0)
                {
                    MessageBox.Show("ID de Productor inválido.", "Error");
                    return;
                }

                // Verificar si existe el Cultivo
                string consultaCultivo = $"SELECT COUNT(*) FROM Cultivos WHERE Id = {cultivoId}";
                int countCultivo = SQLSERVER.ObtenerCantidad(consultaCultivo);

                if (countCultivo == 0)
                {
                    MessageBox.Show("ID de Cultivo inválido.", "Error");
                    return;
                }

                // Insertar solo si ambos existen
                string insertQuery = $@"
            INSERT INTO Detalles (id_productor, id_cultivo)
            VALUES ({productorId}, {cultivoId});";

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
    }
}
