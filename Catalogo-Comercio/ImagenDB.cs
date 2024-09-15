using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;

namespace Catalogo_Comercio
{
    public class ImagenDB
    {
        private readonly List<Imagen> listaImagenes;
        public ImagenDB()
        {
            listaImagenes = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("Select Id, IdArticulo, ImagenUrl From IMAGENES");
                datos.Leer();

                while (datos.Lector.Read())
                {
                    Imagen aux = new Imagen();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.IdArticulo = (int)datos.Lector["IdArticulo"];
                    aux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    listaImagenes.Add(aux);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Mensaje de error: {ex.Message}", $"Error al realizar la consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error: {ex.ToString()}");
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Imagen> GetImagenes(int IdArticulo)
        {
            List<Imagen> imagenes = listaImagenes.Where(clase => clase.IdArticulo == IdArticulo).ToList();

            if (imagenes == null)
                imagenes.Append(new Imagen(-1, IdArticulo, "https://upload.wikimedia.org/wikipedia/commons/a/a3/Image-not-found.png"));

            return imagenes;
        }
        public void AgregarImagen(int IdArticulo, string UrlImagen)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("Insert into Imagenes (IdArticulo, ImagenUrl) values (@IdArticulo, @ImagenUrl)");
                datos.setParametro("@IdArticulo", IdArticulo);
                datos.setParametro("@ImagenUrl", UrlImagen);
                datos.ejecutarConsulta();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        public void eliminarImagen(int idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("Delete from Imagenes where idArticulo = @IdArticulo");
                datos.setParametro("@IdArticulo", idArticulo);
                datos.ejecutarConsulta();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
