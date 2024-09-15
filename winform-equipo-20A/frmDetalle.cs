using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform_Equipo_20A
{
    public partial class frmDetalle : Form
    {
        Articulo articulo = null;
        public frmDetalle()
        {
            InitializeComponent();
        }
        public frmDetalle(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Detalle del articulo";

        }

        private void frmDetalle_Load(object sender, EventArgs e)
        {
            lblMarca.Text = articulo.Marca.Descripcion;
            tbNombre.Text = articulo.Nombre;
            tbDescripcion.Text = articulo.Descripcion;
            tbNombre.ReadOnly = true;
            tbDescripcion.ReadOnly = true;
        }
    }
}
