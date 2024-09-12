using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            ImagenDB imagenDB = new ImagenDB();

            try
            {

                datos.setConsulta("select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, C.Descripcion as Categoria, M.Descripcion as Marca, A.IdCategoria, A.IdMarca From ARTICULOS as A, CATEGORIAS as C, MARCAS as M Where A.IdCategoria = C.Id and A.IdMarca = M.Id");
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
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Imagen = imagenDB.GetImagen(aux.Id);
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
                datos.setConsulta("Insert Into ARTICULOS (Codigo, Nombre, Descripcion, idMarca, idCategoria, Precio) Values (@Codigo,@Nombre,@Descripcion,@idMarca,@idCategoria,@Precio)");
                datos.setParametro("@Codigo", nuevo.Codigo);
                datos.setParametro("@Nombre", nuevo.Nombre);
                datos.setParametro("@Descripcion", nuevo.Descripcion);
                datos.setParametro("@idMarca", nuevo.Marca.Id);
                datos.setParametro("@idCategoria", nuevo.Categoria.Id);
                datos.setParametro("@Precio", nuevo.Precio);
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
        public void modificar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("Update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, idMarca = @idMarca, idCategoria = @idCategoria, Precio = @Precio Where Id = @Id");                
                datos.setParametro("@Id", articulo.Id);
                datos.setParametro("@Codigo", articulo.Codigo);
                datos.setParametro("@Nombre", articulo.Nombre);
                datos.setParametro("@Descripcion", articulo.Descripcion);
                datos.setParametro("@idMarca", articulo.Marca.Id);
                datos.setParametro("@idCategoria", articulo.Categoria.Id);                
                datos.setParametro("@Precio", articulo.Precio);

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
        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "Select A.Id, A.Codigo, A.Nombre,A.Descripcion,Precio, C.Descripcion Categoria, M.Descripcion Marca, A.IdCategoria, A.IdMarca From ARTICULOS A, CATEGORIAS C, MARCAS M Where A.IdCategoria = C.Id and A.IdMarca = M.Id and ";
                if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Precio > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "Precio < " + filtro;
                            break;
                        default:
                            consulta += "Precio = " + filtro;
                            break;
                    }
                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "A.Nombre like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "A.Nombre like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "A.Nombre like '%" + filtro + "%'";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "A.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "A.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "A.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }
                datos.setConsulta(consulta);
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
            //cerrar conexion???
            /*finally
            {
                datos.cerrarConexion();
            }*/
        }
    }
}