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
                MessageBox.Show("Por favor ingresa IDs válidos de productor y cultivo.", "Error");
            }
        }
    }
}
