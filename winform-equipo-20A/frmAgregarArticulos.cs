using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Catalogo_Comercio;

namespace Winform_Equipo_20A
{
    public partial class frmAgregarArticulos : Form
    {
        private Articulo articulo = null;
        public frmAgregarArticulos()
        {
            InitializeComponent();
        }
        public frmAgregarArticulos(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Modificar Articulo";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool SoloNumeros(string cadena)
        {
            int cantComa = 0;
            foreach (char character in cadena)
            {
                if (!(char.IsNumber(character) || character == ','))
                    return false;
                if(character == ',')
                    cantComa++;
                if(cantComa >1)
                    return false;
            }
            return true;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticuloBD articuloBD = new ArticuloBD();
            try
            {
                if (articulo == null)
                    articulo = new Articulo();
                string precio;
                articulo.Codigo = tbCodArticulo.Text;
                articulo.Nombre = tbNombre.Text;
                articulo.Descripcion = tbDescripcion.Text;
                if (string.IsNullOrEmpty(tbPrecio.Text))
                    MessageBox.Show("Debe ingresar un precio");

                else if (!SoloNumeros(tbPrecio.Text))
                    MessageBox.Show("Ingresar solo numeros");

                else
                {
                    precio = tbPrecio.Text;
                    precio = precio.Replace('.', ',');
                    articulo.Precio = decimal.Parse(precio);
                articulo.Marca = (Marca)cbxMarca.SelectedItem;
                articulo.Categoria = (Categoria)cbxCategoria.SelectedItem;
                if (string.IsNullOrEmpty(articulo.Codigo) || string.IsNullOrEmpty(articulo.Nombre))
                    MessageBox.Show("Los campos con * son obligatorios");
                else
                {
                    if (articulo.Id != 0)
                    {
                        articuloBD.modificar(articulo);
                        MessageBox.Show("Modificado con Exito");
                    }
                    else
                    {
                        articuloBD.agregar(articulo);
                        MessageBox.Show("Agregado con Exito!!!");
                    }
                Close();
                }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void frmAgregarArticulos_Load(object sender, EventArgs e)
        {
            MarcaBD marcaBD = new MarcaBD();
            CategoriaBD categoriaBD = new CategoriaBD();

            try
            {
                cbxMarca.DataSource = marcaBD.listar();
                cbxMarca.ValueMember = "id";
                cbxMarca.DisplayMember = "Descripcion";
                cbxCategoria.DataSource = categoriaBD.listar();
                cbxCategoria.ValueMember = "Id";
                cbxCategoria.DisplayMember = "Descripcion";
                if (articulo != null)
                {
                    tbCodArticulo.Text = articulo.Codigo;
                    tbDescripcion.Text = articulo.Descripcion;
                    tbNombre.Text = articulo.Nombre;
                    tbPrecio.Text = articulo.Precio.ToString();
                    cbxCategoria.SelectedValue = articulo.Categoria.Id;
                    cbxMarca.SelectedValue = articulo.Marca.Id;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }
    }
}
