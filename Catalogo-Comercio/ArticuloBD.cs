using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Dominio;


namespace Catalogo_Comercio
{
    public class ArticuloBD
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("Select A.Id, A.Codigo, A.Nombre,A.Descripcion,Precio, C.Descripcion Categoria, M.Descripcion Marca, A.IdCategoria, A.IdMarca From ARTICULOS A, CATEGORIAS C, MARCAS M Where A.IdCategoria = C.Id and A.IdMarca = M.Id ");
                datos.Leer();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                   // aux.Imagen = (Imagen)datos.Lector["Imagen"];
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
        public void agregar(Articulo nuevo) // public?
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
        public void modificar(Articulo nuevoArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("Update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, Marca = @Marca, Categoria = @Categoria, Imagen = @Imagen, Precio = @Precio Where Id = @Id");
                datos.setParametro("@Id", nuevoArticulo.Id);
                datos.setParametro("@Codigo", nuevoArticulo.Codigo);
                datos.setParametro("@Nombre", nuevoArticulo.Nombre);
                datos.setParametro("@Descripcion", nuevoArticulo.Descripcion);
                datos.setParametro("@Marca", nuevoArticulo.Marca);
                datos.setParametro("@Categoria", nuevoArticulo.Categoria);
                datos.setParametro("@Imagen", nuevoArticulo.Imagen);
                datos.setParametro("@Precio", nuevoArticulo.Precio);

                datos.ejecutarAccion();
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
