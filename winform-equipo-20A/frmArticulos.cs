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
        Articulo seleccionado = null;
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

        private void CargarImagen(string url)
        {
            try
            {
                pbxArticulo.Load(url);
                pbxArticulo.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch (Exception)
            {
                pbxArticulo.Load("https://upload.wikimedia.org/wikipedia/commons/a/a3/Image-not-found.png");
            }
        }

        private void frmArticulos_Load(object sender, EventArgs e)
        {
            CargarDatos();
            cbxCampo.Items.Add("Nombre");
            cbxCampo.Items.Add("Descripcion");
            cbxCampo.Items.Add("Precio");
        }

        //oculta las columnas en el data grid view
        private void OcultarColumnas()
        {
            dgvArticulos.Columns["Id"].Visible = false;
            // dgvArticulos.Columns["Codigo"].Visible = false;
            dgvArticulos.Columns["Imagen"].Visible = false;
            dgvArticulos.Columns["Descripcion"].Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarArticulos agregarArticulo = new frmAgregarArticulos();
            agregarArticulo.ShowDialog();
            CargarDatos();
        }
        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null)
            {
                seleccionado = (Articulo) dgvArticulos.CurrentRow.DataBoundItem;
                CargarImagen(seleccionado.Imagen.UrlImagen);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvArticulos.SelectedRows.Count != 0)
                {
                    seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    frmAgregarArticulos modificar = new frmAgregarArticulos(seleccionado);
                    modificar.ShowDialog();
                    CargarDatos();
                }
                else
                    MessageBox.Show("Selecione un articulo para poder modificarlo");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void tbFiltroCodigo_TextChanged(object sender, EventArgs e)
        {
            filtroRapido();
        }

        private void filtroRapido()
        {
            List<Articulo> listaFiltrada;
            string filtro = tbFiltroCodigo.Text;
            if (filtro.Length >= 1)
            {
                listaFiltrada = listaArticulo.FindAll(x => x.Codigo.ToLower().Contains(filtro.ToLower()));
            }
            else
                listaFiltrada = listaArticulo;
            dgvArticulos.DataSource = null;
            dgvArticulos.DataSource = listaFiltrada;
            OcultarColumnas();

        }

        private void btnFiltroAvanzado_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            cbxCampo.SelectedIndex = -1;
            cbxCriterio.SelectedIndex = -1;
        }

        private void cbxCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCampo.SelectedItem != null)
            {

                string campo = cbxCampo.SelectedItem.ToString();
                if (campo == "Precio")
                {
                    cbxCriterio.Items.Clear();
                    cbxCriterio.Items.Add("Menores a");
                    cbxCriterio.Items.Add("Hasta");
                    cbxCriterio.Items.Add("Mayores a ");
                }
                else
                {
                    cbxCriterio.Items.Clear();
                    cbxCriterio.Items.Add("Todos");
                    cbxCriterio.Items.Add("Empieza con");
                    cbxCriterio.Items.Add("Termina con");
                    cbxCriterio.Items.Add("Contiene");
                }
            }
        }
    }
}
