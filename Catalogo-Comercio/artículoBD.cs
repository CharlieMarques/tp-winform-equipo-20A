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
    public class ArtículoBD
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("Select Id, Codigo, Nombre, Descripcion, Marca, Categoria, Imagen, Precio From ARTICULOS");
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = (Marca)datos.Lector["Marca"];
                    aux.Categoria = (Categoria)datos.Lector["Categoria"];
                    aux.Imagen = (Imagen)datos.Lector["Imagen"];
                    aux.Precio = (float)datos.Lector["Precio"];
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
        void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("Insert Into ARTICULOS (Id, Codigo, Nombre, Descripcion, Marca, Categoria, Imagen, Precio) Values ('" + nuevo.Id + "', '" + nuevo.Codigo + "', '" + nuevo.Nombre + "', '" + nuevo.Descripcion + "', '" + nuevo.Marca + "', '" + nuevo.Categoria + "', '" + nuevo.Imagen + "', '" + nuevo.Precio + "')");
                datos.ejecutarConsulta();
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
