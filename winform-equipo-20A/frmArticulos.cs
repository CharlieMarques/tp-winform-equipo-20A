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
        private ArticuloBD articuloBD = new ArticuloBD();

        Articulo seleccionado;
        public frmArticulos()
        {
            InitializeComponent();
        }
        private void CargarDatos()
        {
            listaArticulo = articuloBD.listar();
            dgvArticulos.DataSource = listaArticulo;
            OcultarColumnas();
            CargarImagen(listaArticulo[0].Imagen.UrlImagen);
        }

        private void CargarImagen(string url)
        {
            try
            {
                pbxArticulo.Load(url);
                pbxArticulo.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Mensaje de error: {ex.Message}", $"Error al realizar la consulta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Console.WriteLine($"Error: {ex.ToString()}");
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
                else MessageBox.Show($"Selecione un articulo para poder modificarlo", $"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Mensaje de error: {ex.Message}", $"Error al realizar la consulta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Console.WriteLine($"Error: {ex.ToString()}");
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
        private bool sinSeleccion(ComboBox cbx)
        {
            if (cbx.SelectedIndex < 0)
                return true;
            else
                return false;
                  
        }
        private bool soloNumeros(string cadena)
        {
            foreach(char character in cadena)
            {
                if(!(char.IsNumber(character)))
                    return false;
            }
            return true;
        }
        private void btnFiltroAvanzado_Click(object sender, EventArgs e)
        {
            //ArticuloBD articulo = new ArticuloBD();
            try
            {
                string campo, criterio, filtro;
                if (sinSeleccion(cbxCampo)) MessageBox.Show($"Complete el campo y criterio a filtrar", $"Error al filtrar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    campo = cbxCampo.SelectedItem.ToString();
                    if(sinSeleccion(cbxCriterio))
                    {
                        if(campo != "Precio")
                        {
                            cbxCriterio.SelectedItem = "Todos";
                            criterio = "Todos";
                        }
                        else
                        {
                            cbxCriterio.SelectedItem = "Hasta";
                            criterio = "Hasta";
                        }
                    }
                    else
                        criterio = cbxCriterio.SelectedItem.ToString();
                    if ((string)cbxCampo.SelectedItem == "Precio" && !(soloNumeros(tbFiltroAvanzado.Text)))
                        MessageBox.Show("Ingresar solo numeros");
                    else if((string)cbxCampo.SelectedItem == "Precio" && string.IsNullOrEmpty(tbFiltroAvanzado.Text))
                    {
                        MessageBox.Show("El filtro no puede quedar vacio para poder filtrar por precio");
                        CargarDatos();
                    }
                    else
                    {
                        filtro = tbFiltroAvanzado.Text;
                        List<Articulo> listaArticulo_ = articuloBD.filtrar(campo, criterio, filtro);
                        dgvArticulos.DataSource = listaArticulo_;
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            cbxCampo.SelectedIndex = -1;
            cbxCriterio.SelectedIndex = -1;
            tbFiltroAvanzado.Text = null;
            CargarDatos();
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ArticuloBD articuloEliminar = new ArticuloBD();
            try
            {
            if(dgvArticulos.SelectedRows.Count !=0)
            {
                DialogResult repuesta = MessageBox.Show("¿Realmente desea eliminar este articulo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (repuesta == DialogResult.Yes)
                {
                    seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    articuloEliminar.Eliminar(seleccionado.Id);
                    CargarDatos();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un articulo para eliminar");
            }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
