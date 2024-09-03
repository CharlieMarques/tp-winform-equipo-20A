using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

public static class ConfiguracionGlobal
{
    // modificar el string de coneccion al que tengan para que funcione
    public static string StringDeConeccion = "Server=localhost,1433;Database=CATALOGO_P3_DB;User Id=sa;Password=yourStrong#Password;";
}

namespace Winform_Equipo_20A
{
    public partial class frmArticulos : Form
    {
        public frmArticulos()
        {
            InitializeComponent();
            CargarDatos(); // Llama al método para cargar los datos al iniciar el formulario
        }

        private void CargarDatos()
        {
            // conneccion a la base de datos
            string connectionString = ConfiguracionGlobal.StringDeConeccion; 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM Articulos"; // selecciona la tabla articulos
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable; // Asigna los datos al DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar con la base de datos: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lógica para manejar el clic en el contenido de las celdas, creo que no es necesario?
        }

        private void textBoxBusqueda_TextChanged(object sender, EventArgs e)
        {
            string codigoBusqueda = textBoxBusqueda.Text.Trim();
            BuscarPorCodigo(codigoBusqueda);
        }

        private void BuscarPorCodigo(string codigo)
        {
            string connectionString = ConfiguracionGlobal.StringDeConeccion;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Consulta SQL con filtro por código
                    string query = "SELECT * FROM Articulos WHERE Codigo LIKE @Codigo";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                    // Usar parámetro para evitar inyecciones SQL
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@Codigo", "%" + codigo + "%");

                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar con la base de datos: " + ex.Message);
                }
            }
        }

    }
}

