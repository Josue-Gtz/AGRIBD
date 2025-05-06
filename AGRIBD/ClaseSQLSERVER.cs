using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Drawing;


namespace AGRIBD
{
    internal class ClaseSQLSERVER
    {
        private string Servidor = "JOSUE\\SQLEXPRESS";
        private string Basedatos = "AGRIBD";
        private string UsuarioId = "sa";
        private string Password = "2050";

        /// <summary>
        /// Obtiene la cadena de conexión para SQL Server.
        /// </summary>
        /// <returns>Cadena de conexión a SQL Server.</returns>

        /// <summary>
        /// Ejecuta un comando SQL en SQL Server.
        /// </summary>
        /// <param name="ConsultaSQL">Consulta SQL a ejecutar.</param>
        public (DataSet, SqlCommand) EjecutarComandos(string ConsultaSQL, string NomTabla)
        {
            try
            {
                // Cadena de conexión a la base de datos
                string strConn = $"Server={Servidor};" +
                    $"Database={Basedatos};" +
                    $"User Id={UsuarioId};" +
                    $"Password={Password}";

                // Creación y apertura de la conexión
                SqlConnection conn = new SqlConnection(strConn);
                conn.Open();

                // Creación del comando SQL
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = ConsultaSQL;
                cmd.ExecuteNonQuery();

                // Retorno del DataSet llenado y el comando ejecutado
                return (llenarGrids(NomTabla), cmd);
            }
            catch (SqlException Ex)
            {
                // Manejo de excepciones SQL
                MessageBox.Show(Ex.Message);
                return (null, null);
            }
            catch (Exception Ex)
            {
                // Manejo de excepciones generales
                MessageBox.Show("Error en el sistema: " + Ex.Message);
                return (null, null);
            }
        }

        /// <summary>
        /// Obtiene datos de SQL Server según la consulta dada.
        /// </summary>
        /// <param name="consulta">Consulta SQL para obtener datos.</param>
        /// <returns>DataTable con los resultados de la consulta.</returns>

        public DataSet llenarGrids(string NomTabla)
        {
            DataSet ds = new DataSet();
            try
            {
                // Cadena de conexión a la base de datos
                string strConn = $"Server={Servidor};" +
                                 $"Database={Basedatos};" +
                                 $"User Id={UsuarioId};" +
                                 $"Password={Password}";

                // Uso de la conexión en un bloque using para asegurar su cierre
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    conn.Open();

                    // Consulta SQL para seleccionar todos los datos de la tabla
                    string sqlQuery = $"select * from {NomTabla}";
                    SqlDataAdapter adp = new SqlDataAdapter(sqlQuery, conn);

                    // Llenado del DataSet con los datos de la tabla
                    adp.Fill(ds, $"{NomTabla}");

                }
            }
            catch (SqlException Ex)
            {
                // Manejo de excepciones SQL
                MessageBox.Show(Ex.Message);
            }
            catch (Exception Ex)
            {
                // Manejo de excepciones generales
                MessageBox.Show("Error en el sistema: " + Ex.Message);
            }
            return ds;
        }

        public (Label, DataGridView) CrearYMostrarDataGridView(DataSet ds, string nombreTabla)
        {
            // Creación de un nuevo DataGridView
            DataGridView dgv = new DataGridView
            {
                DataSource = ds.Tables[0],
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Location = new Point(10, 325),
                Size = new Size(800, 200),
                Name = "dgv" + nombreTabla,
                Visible = true
            };


            // Creación de un nuevo Label para mostrar el nombre de la tabla
            Label lbl = new Label
            {
                Text = "Tabla: " + nombreTabla,
                Location = new Point(10, dgv.Location.Y - 20),
                AutoSize = true,
                Visible = true
            };

            // Retorno del Label y el DataGridView creados
            return (lbl, dgv);
        }
        public DataSet EjecutarConsultaSelect(string consultaSQL, string nombreTabla)
        {
            DataSet ds = new DataSet();

            try
            {
                string strConn = $"Server={Servidor};Database={Basedatos};User Id={UsuarioId};Password={Password}";

                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    conn.Open();
                    SqlDataAdapter adp = new SqlDataAdapter(consultaSQL, conn);
                    adp.Fill(ds, nombreTabla);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la consulta SELECT: " + ex.Message);
            }

            return ds;
        }
        // Ewe



    }
}

