using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Imagen GetImagen(int IdArticulo)
        {
            Imagen imagen = listaImagenes.FirstOrDefault(clase => clase.IdArticulo == IdArticulo);
            
            if (imagen == null)
                imagen = new Imagen(-1, IdArticulo, "https://upload.wikimedia.org/wikipedia/commons/a/a3/Image-not-found.png");
            
            return imagen;
        }
    }
}
