using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalogo_Comercio;
using System.Xml.Linq;
using Dominio;

namespace Catalogo_Comercio
{
    public class Catalogo_Comercio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("Select Id, Descripcion From ELEMENTOS");
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    // -- Hay que guardar los datos de forma apropiada para estas clases --
                    //aux.Marca = (Marca)datos.Lector["Marca"];
                    //aux.Categoria = (Categoria)datos.Lector["Categoria"];
                    //aux.Imagen= (Imagen)datos.Lector["Imagen"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    lista.Add(aux);
                }
                return lista;
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
    }
}
