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
        }

        private void frmArticulos_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}
