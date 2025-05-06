using System; // Wey
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
    public partial class Reportes : Form
    {
        public Reportes()
        {
            InitializeComponent();
        }

        ClaseSQLSERVER SQLSERVER = new ClaseSQLSERVER();

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int productorId))
            {
                MessageBox.Show("Por favor ingresa un ID válido de productor.");
                return;
            }

            string consulta = $@"
        SELECT 
            p.id AS IdProductor,
            p.nombre AS NombreProductor,
            p.email,
            p.direccion,
            c.id AS IdCultivo,
            c.nombre AS NombreCultivo,
            c.plantacion,
            c.tamaño
        FROM 
            Productores p
        JOIN 
            Detalles d ON p.id = d.id_productor
        JOIN 
            Cultivos c ON c.id = d.id_cultivo
        WHERE 
            p.id = {productorId};";

            var ds = SQLSERVER.EjecutarConsultaSelect(consulta, "ReporteProductor");

            if (ds != null && ds.Tables.Count > 0)
            {
                var controles = SQLSERVER.CrearYMostrarDataGridView(ds, "ReporteProductor");

                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is DataGridView || ctrl is Label)
                        this.Controls.Remove(ctrl);
                }

                this.Controls.Add(controles.Item1); // Label
                this.Controls.Add(controles.Item2); // DataGridView

            }
        }
    }
}