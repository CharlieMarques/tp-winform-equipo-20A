using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Catalogo_Comercio;
using Dominio;

namespace Winform_Equipo_20A
{
    public partial class frmArticulos : Form
    {
        private List<Articulo> listaArticulo;
        public frmArticulos()
        {
            InitializeComponent();
        }
        private void CargarDatos()
        {
            ArticuloBD articuloBD = new ArticuloBD();
            listaArticulo = articuloBD.listar();
            
            dgvArticulos.DataSource = listaArticulo;
            OcultarColumnas();
        }

        private void frmArticulos_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        //oculta las columnas en el data grid view
        private void OcultarColumnas()
        {
            dgvArticulos.Columns["Id"].Visible = false;
            dgvArticulos.Columns["Codigo"].Visible = false;
            dgvArticulos.Columns["Imagen"].Visible = false;
            dgvArticulos.Columns["Descripcion"].Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarArticulos agregarArticulo = new frmAgregarArticulos();
            agregarArticulo.ShowDialog();
            CargarDatos();
        }
    }
}
