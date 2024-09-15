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
using System.Net;

namespace Winform_Equipo_20A
{
    public partial class frmAgregarArticulos : Form
    {
        private Articulo articulo = null;
        private Imagen imagen = null;
        private bool AgregarOtraImagen = false;
        public frmAgregarArticulos()
        {
            InitializeComponent();
            AgregarOtraImagen = false;
        }
        public frmAgregarArticulos(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Modificar Articulo";
            AgregarOtraImagen = false;
        }
        public frmAgregarArticulos(Articulo articulo, Imagen imagen, bool AgregarImagen)
        {
            InitializeComponent();
            this.articulo = articulo;
            this.imagen = imagen;
            AgregarOtraImagen = AgregarImagen;

            Text = "Agregar Foto";
            tbCodArticulo.ReadOnly = true;
            tbNombre.ReadOnly = true;
            tbDescripcion.ReadOnly = true;
            tbPrecio.ReadOnly = true;
            cbxCategoria.Enabled = false;
            cbxMarca.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool esDecimal(string cadena)
        {
            return decimal.TryParse(cadena, out decimal res);
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticuloBD articuloBD = new ArticuloBD();
            ImagenDB imagenDB = new ImagenDB();
            try
            {
                if (articulo == null)
                    articulo = new Articulo();
                string precio;
                articulo.Codigo = tbCodArticulo.Text;
                articulo.Nombre = tbNombre.Text;
                articulo.Descripcion = tbDescripcion.Text;
                if (string.IsNullOrEmpty(tbPrecio.Text))
                {
                    MessageBox.Show($"Debe ingresar el precio", $"Warining", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!esDecimal(tbPrecio.Text))
                {
                    MessageBox.Show($"El precio debe ser un número válido", $"Warining", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    precio = tbPrecio.Text;
                    precio = precio.Replace('.', ',');
                    articulo.Precio = decimal.Parse(precio);
                    articulo.Marca = (Marca)cbxMarca.SelectedItem;
                    articulo.Categoria = (Categoria)cbxCategoria.SelectedItem;
                    if (string.IsNullOrEmpty(articulo.Codigo) || string.IsNullOrEmpty(articulo.Nombre))
                    {
                        MessageBox.Show($"Los campos con asterisco (*) son obligatorios", $"Warining", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (!AgregarOtraImagen)
                        {
                            if (articulo.Id != 0)
                            {
                                articuloBD.modificar(articulo);
                                MessageBox.Show($"Se modificó exitosamente", $"Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close();
                            }
                            else if (!articuloBD.CheckCodigo(articulo.Codigo))
                            {
                                if (!(string.IsNullOrEmpty(tbImagen.Text)))
                                    imagenDB.AgregarImagen(articuloBD.agregar(articulo), tbImagen.Text);
                                else
                                    articuloBD.agregar(articulo);
                                MessageBox.Show($"Se agregó exitosamente", $"Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close();
                            }
                            else
                                MessageBox.Show("El Codigo de Articulo ya existe");
                        }
                        else
                        {
                            imagenDB.AgregarImagen(articulo.Id, tbImagen.Text);
                            MessageBox.Show($"Se agregó exitosamente La imagen", $"Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Mensaje de error: {ex.Message}", $"Error al cargar los artículos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error: {ex.ToString()}");
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
                MessageBox.Show($"Mensaje de error: {ex.Message}", $"Error al cargar las marcas y categorias", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error: {ex.ToString()}");
            }
        }
    }
}
